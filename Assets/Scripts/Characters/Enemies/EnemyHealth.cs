using System;
using Characters.Base;
using Data.Core;
using Databases;
using Pooling;
using UI.Game;
using UnityEngine;

namespace Characters.Enemies
{
    public class EnemyHealth : HealthComponent
    {
        [Header("UI")]
        [SerializeField] private EnemyHealthBar healthBar;

        [Header("Hit Effects")]
        [SerializeField] private ParticleData hitVFX;

        private EnemyAnimator _animator;

        public ParticleData DeathVFX { get; set; }

        private ParticleData HitVFX
        {
            get => hitVFX;
            set => hitVFX = value;
        }

        private void SetAnimator(EnemyAnimator animator) => _animator = animator;

        private void HandleDamageTaken()
        {
            if (healthBar != null)
                healthBar.UpdateHealthBarValue(HealthBarValue);
        }

        private void HandleDirectionalDamage(Vector3 hitDirection)
        {
            if (_animator != null)
                _animator.PlayHitReaction(hitDirection);

            if (hitVFX != null)
            {
                var hitPosition = transform.position + Vector3.up;
                var hitRotation = Quaternion.LookRotation(-hitDirection);
                GamePoolManager.Instance?.GetParticlePrefab(hitVFX, hitPosition, hitRotation);
            }
        }

        private void HandleDeath()
        {
            if (DeathVFX != null)
                GamePoolManager.Instance?.GetParticlePrefab(DeathVFX, transform.position, transform.rotation);
        }

        private void OnEnable()
        {
            OnDeath += HandleDeath;
            OnDamageTaken += HandleDamageTaken;
            OnDamageTakenWithDirection += HandleDirectionalDamage;
        }

        private void OnDisable()
        {
            OnDeath -= HandleDeath;
            OnDamageTaken -= HandleDamageTaken;
            OnDamageTakenWithDirection -= HandleDirectionalDamage;
        }
    }
}
