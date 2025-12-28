using Audio;
using Databases;
using UnityEngine;
using Weapons;

namespace Characters.Enemies
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Characters/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        #region Fields
        
        [Header("Identity")]
        [SerializeField] private string enemyId;

        [Header("Stats")]
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private float moveSpeed = 3.5f;

        [Header("Presentation")]
        [SerializeField] private GameObject prefab;

        [SerializeField] private WorldAudioData[] ambientSfx;
        [SerializeField] private WorldAudioData[] hitSfx;
        [SerializeField] private WorldAudioData[] deathSfx;
        [SerializeField] private ParticleData deathVFX;

        [Header("Combat")] 
        [SerializeField] private WeaponData weapon;

        #endregion
        
        #region Methods
        
        private WorldAudioData GetAmbientSfx()
        {
            if(ambientSfx == null) return null;
            var sfx = Random.Range(0, ambientSfx.Length);
            return ambientSfx[sfx];
        }

        private WorldAudioData GetHitSfx()
        {
            if(hitSfx == null) return null;
            var sfx = Random.Range(0, hitSfx.Length);
            return hitSfx[sfx];
        }
        
        private WorldAudioData GetDeathSfx()
        {
            if(deathSfx == null) return null;
            var sfx = Random.Range(0, deathSfx.Length);
            return deathSfx[sfx];
        }
        
        #endregion
        
        #region Properties

        public string EnemyId => enemyId;
        public int MaxHealth => maxHealth;
        public float MoveSpeed => moveSpeed;
        public GameObject Prefab => prefab;
        public WorldAudioData AmbientSfx => GetAmbientSfx();
        public WorldAudioData HitSfx => GetHitSfx();
        public WorldAudioData DeathSfx => GetDeathSfx();
        public ParticleData DeathVFX => deathVFX;
        
        #endregion

        
    }
}
