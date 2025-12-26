using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;
using Characters.Enemies;
using Databases;
using Systems;
using Visual_Effects;
using Weapons;

namespace Pooling
{
    public class GamePoolManager : MonoBehaviour
    {
        #region Singleton

        public static GamePoolManager Instance { get; private set; }

        #endregion
        
        #region Performance Settings
        
        [Header("Pool Load Settings")]
        [SerializeField] private int prewarmCount = 5;
        private bool _isPrewarming;
        
        [Header("VR Performance Settings")]
        [SerializeField] private bool enableCollectionCheck;
        [SerializeField] private int poolSize = 50;
        [SerializeField] private int maxPoolSize = 100;
        
        private VFXPriorityRouter _vfxRouter;
        
        #endregion
        
        #region Pools
        
        private readonly Dictionary<EnemyData, ObjectPool<GameObject>> _enemyPoolDictionary = new();
        private readonly Dictionary<WeaponData, ObjectPool<GameObject>> _weaponPoolDictionary = new();
        private readonly Dictionary<ParticleData, ObjectPool<GameObject>> _particlePoolDictionary = new();
        
        #endregion
        
        #region Pool Creation Methods
        
        private ObjectPool<GameObject> CreateEnemyPrefabPool(EnemyData data)
        {
            return new ObjectPool<GameObject>(
                createFunc: () =>
                {
                    var obj = Instantiate(data.Prefab);
                    obj.SetActive(false);
                    return obj;
                },
                actionOnGet: OnGet,
                actionOnRelease: OnEnemyRelease,
                actionOnDestroy: Destroy,
                collectionCheck: enableCollectionCheck && Application.isEditor,
                defaultCapacity: poolSize,
                maxSize: maxPoolSize
            );
        }

        private ObjectPool<GameObject> CreateWeaponPrefabPool(WeaponData data)
        {
            return new ObjectPool<GameObject>(
                createFunc: () =>
                {
                    var obj = Instantiate(data.WeaponPrefab);
                    obj.SetActive(false);
                    return obj;
                },
                actionOnGet: OnGet,
                actionOnRelease: OnWeaponRelease,
                actionOnDestroy: Destroy,
                collectionCheck: enableCollectionCheck && Application.isEditor,
                defaultCapacity: poolSize,
                maxSize: maxPoolSize
            );
        }

        private ObjectPool<GameObject> CreateParticlePool(ParticleData data)
        {
            return new ObjectPool<GameObject>(
                createFunc: () =>
                {
                    var obj = Instantiate(data.Prefab);
                    var particle = obj.GetComponent<ParticleController>();
                    particle.Initialise(data);
                    obj.SetActive(false);
                    return obj;
                },
                actionOnGet: OnGet,
                actionOnRelease: OnParticleRelease,
                actionOnDestroy: Destroy,
                collectionCheck: enableCollectionCheck && Application.isEditor,
                defaultCapacity: poolSize,
                maxSize: maxPoolSize
            );
        }

        private void CreateEnemyPools()
        {
            foreach (var enemyData in GameDatabases.EnemyDatabase.Entries)
            {
                if (_enemyPoolDictionary.ContainsKey(enemyData)) continue;

                var pool = CreateEnemyPrefabPool(enemyData);
                _enemyPoolDictionary[enemyData] = pool;

                var temp = new List<GameObject>();
                for (var i = 0; i < prewarmCount; i++)
                    temp.Add(pool.Get());

                foreach (var obj in temp)
                    pool.Release(obj);
            }
        }

        private void CreateWeaponPools()
        {
            foreach (var weaponData in GameDatabases.WeaponDatabase.Entries)
            {
                if(_weaponPoolDictionary.ContainsKey(weaponData)) continue;

                var pool = CreateWeaponPrefabPool(weaponData);
                _weaponPoolDictionary[weaponData] = pool;
                
                var temp = new List<GameObject>();
                for (var i = 0; i < prewarmCount; i++)
                    temp.Add(pool.Get());

                foreach (var obj in temp)
                    pool.Release(obj);
            }
        }

        private void CreateParticlePools()
        {
            foreach (var particleData in GameDatabases.ParticleDatabase.Entries)
            {
                if(_particlePoolDictionary.ContainsKey(particleData)) continue;
                
                var pool = CreateParticlePool(particleData);
                _particlePoolDictionary[particleData] = pool;
                
                var temp = new List<GameObject>();
                for(var i = 0; i < prewarmCount; i++)
                    temp.Add(pool.Get());
                
                foreach (var obj in temp)
                    pool.Release(obj);
            }
        }
        
        private void PrewarmPools()
        {
            _isPrewarming = true;
            CreateEnemyPools();
            CreateWeaponPools();
            CreateParticlePools();
            _isPrewarming = false;
        }
        
        #endregion
        
        #region Pool Access Methods

        private static void OnGet(GameObject obj) { }

        private void OnEnemyRelease(GameObject obj)
        {
            if (!_isPrewarming)
                obj.GetComponent<EnemyController>()?.OnDespawn();
            
            obj.SetActive(false);
        }

        private void OnWeaponRelease(GameObject obj)
        {
            // if (!_isPrewarming)
                // TODO: Weapon Controller
                
            obj.SetActive(false);
        }

        private void OnParticleRelease(GameObject obj)
        {
            // TODO: Particle Controller Reset
            obj.SetActive(false);
        }
        
        public GameObject GetEnemyPrefab(EnemyData data, Vector3 position, Quaternion rotation)
        {
            if (!_enemyPoolDictionary.TryGetValue(data, out var pool))
            {
                Debug.LogError($"No enemy pool found for {data.name}");
                return null;
            }

            var obj = pool.Get();
            obj.transform.SetPositionAndRotation(position, rotation);

            var controller = obj.GetComponent<EnemyController>();
            controller.OnSpawn(data);
            
            obj.SetActive(true);
            return obj;
        }
        
        public void ReturnEnemyPrefab(EnemyController enemy)
        {
            var data = enemy.Data;

            if (_enemyPoolDictionary.TryGetValue(data, out var pool))
                pool.Release(enemy.gameObject);
            else
                Destroy(enemy.gameObject);
        }

        public GameObject GetParticlePrefab(ParticleData data, Vector3 position, Quaternion rotation)
        {
            if (!_vfxRouter.CanSpawn(data.Priority))
                return null;

            if (!_particlePoolDictionary.TryGetValue(data, out var pool))
                return null;

            _vfxRouter.RegisterSpawn();
            
            var obj = pool.Get();
            obj.transform.SetPositionAndRotation(position, rotation);

            var controller = obj.GetComponent<ParticleController>();
            
            obj.SetActive(true);
            controller.Play();
            return obj;
        }

        public void ReturnParticlePrefab(ParticleController particle)
        {
            var data = particle.Data;
            _vfxRouter.RegisterDespawn();
            
            if (_particlePoolDictionary.TryGetValue(data, out var pool))
                pool.Release(particle.gameObject);
            else
                Destroy(particle.gameObject);
        }

        #endregion
        
        #region Unity Methods
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                PrewarmPools();
                _vfxRouter = GetComponentInChildren<VFXPriorityRouter>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}