using System;
using Data.Core;
using Events.Registries;
using Pooling;
using UnityEngine;

namespace Characters.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private EnemyData enemyData;

        private EnemyMovement _enemyMovement;
        private EnemyAnimator _enemyAnimator;
        private EnemyHealth _enemyHealth;
        private EnemyAttack _enemyAttack;
        private EnemyId _enemyId;

        private GamePoolManager _gamePoolManager;

        public EnemyData Data
        {
            get => enemyData;
            set => enemyData = value;
        }

        public Action OnDeath { get; set; }
        public EnemyAnimator Animator => _enemyAnimator;
        public EnemyMovement Movement => _enemyMovement;

        public void DebugKillEnemy() => HandleEnemyDeath();

        private void HandleEnemyDeath()
        {
            _enemyMovement.SetDead();
            _enemyAttack.ResetAttack();

            if(!_gamePoolManager)
                _gamePoolManager = GamePoolManager.Instance;

            _gamePoolManager.ReturnEnemyPrefab(this);
            _gamePoolManager.GetWorldAudioPrefab(enemyData?.DeathSfx, transform.position);

            OnDeath?.Invoke();
        }

        private void InitEnemy()
        {
            _enemyId.ID = enemyData.EnemyId;
            _enemyHealth.OnSpawn(enemyData.MaxHealth, HandleEnemyDeath);
            _enemyHealth.DeathVFX = enemyData.DeathVFX;
            _enemyAnimator.OnSpawn();
            _enemyMovement.OnSpawn(enemyData.MoveSpeed, _enemyAnimator);
            _enemyAttack?.InitAttack(enemyData.Weapon, _enemyAnimator, _enemyMovement);
            GameplayEvents.EnemySpawned.Raise(this);
        }

        public void OnSpawn(EnemyData data)
        {
            enemyData = data;
            InitEnemy();
        }

        public void OnDespawn()
        {
            _enemyAnimator.OnDespawn();
            _enemyMovement.OnDespawn();
            _enemyAttack?.ResetAttack();
            _enemyHealth.OnDespawn(HandleEnemyDeath);
            GameplayEvents.EnemyDespawned.Raise(this);
        }

        public void HighPriorityUpdate()
        {
            _enemyMovement?.UpdateAI();

            if (_enemyMovement && _enemyMovement.IsInAttackRange)
                TryAttack();
        }

        private void TryAttack()
        {
            if (!_enemyAttack) return;
            if (_enemyAttack.CanAttack)
                _enemyAttack.TryAttack();
        }

        private void CacheComponents()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
            _enemyId = GetComponent<EnemyId>();
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _enemyAttack = GetComponent<EnemyAttack>();
            _gamePoolManager = GamePoolManager.Instance;
        }

        private void Awake() => CacheComponents();
    }
}
