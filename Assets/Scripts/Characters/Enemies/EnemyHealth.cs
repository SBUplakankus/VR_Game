using System;
using Characters.Base;
using Databases;
using Events;
using Pooling;
using UI.Game;
using UnityEngine;

namespace Characters.Enemies
{
    public class EnemyHealth : HealthComponent
    {
        [SerializeField] private EnemyHealthBar  healthBar;
        
        public ParticleData DeathVFX {get; set;}
        
        private void OnEnable()
        {
            OnDeath += HandleDeath;
            OnDamageTaken += HandleDamageTaken;
        }

        private void OnDisable()
        {
            OnDeath -= HandleDeath;
            OnDamageTaken -= HandleDamageTaken;
        } 
        
        private void HandleDamageTaken()
        {
            healthBar.UpdateHealthBarValue(HealthBarValue);
        }

        private void HandleDeath()
        {
            GamePoolManager.Instance.GetParticlePrefab(DeathVFX, transform.position, transform.rotation);
        }
    }
}