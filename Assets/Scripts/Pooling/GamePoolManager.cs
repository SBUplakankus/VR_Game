using System;
using Events.Data;
using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;
using Characters.Enemies;
using PrimeTween;
using Unity.Tutorials.Core.Editor;
using UnityEngine.Localization;

namespace Pooling
{
    public class GamePoolManager : MonoBehaviour
    {
        #region Singleton

        public static GamePoolManager Instance { get; private set; }

        #endregion
        
        #region Performance Settings
        [Header("VR Performance Settings")]
        [SerializeField] private bool enableCollectionCheck = false;
        [SerializeField] private int poolSize = 50;
        [SerializeField] private int maxPoolSize = 100;
        #endregion
        
        #region Pools
        private ObjectPool<DamageEventData> _damagePool;
        private ObjectPool<LocalizedString> _localizedStringPool;
        private ObjectPool<EnemyController> _enemyPool;
        
        private readonly Dictionary<Type, object> _poolDictionary = new();
        #endregion
        
        #region Methods
        private void InitPools()
        {
            // Damage Event Pool - medium frequency
            _damagePool = new ObjectPool<DamageEventData>(
                createFunc: () => new DamageEventData(),
                actionOnGet: null, // No extra work on get
                actionOnRelease: data => data.Reset(),
                actionOnDestroy: null, // No destruction logging
                collectionCheck: enableCollectionCheck && Application.isEditor, // Editor only!
                defaultCapacity: poolSize,
                maxSize: poolSize * 10 // Allow growth but with limit
            );
            
            // Register pools for easy access
            _poolDictionary[typeof(DamageEventData)] = _damagePool;

            
        }
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitPools();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        // Generic method for any pool
        public T GetFromPool<T>() where T : class, new()
        {
            if (_poolDictionary.TryGetValue(typeof(T), out var poolObj))
            {
                return ((ObjectPool<T>)poolObj).Get();
            }
            
            // Auto-create pool if it doesn't exist (lazy initialization)
            Debug.LogWarning($"Pool for {typeof(T).Name} not found, creating default");
            return CreateDefaultPool<T>().Get();
        }
        
        public void ReturnToPool<T>(T item) where T : class
        {
            if (!_poolDictionary.TryGetValue(typeof(T), out var poolObj)) return;
            var pool = poolObj as ObjectPool<T>;
            pool?.Release(item);
        }
        
        private ObjectPool<T> CreateDefaultPool<T>() where T : class, new()
        {
            var pool = new ObjectPool<T>(
                createFunc: () => new T(),
                actionOnGet: null,
                actionOnRelease: null,
                actionOnDestroy: null,
                collectionCheck: false,
                defaultCapacity: 20,
                maxSize: 200
            );
            
            _poolDictionary[typeof(T)] = pool;
            return pool;
        }
        
        #endregion
    }
}