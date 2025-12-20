using System;
using Characters.Base;
using Events;

namespace Characters.Enemies
{
    public class EnemyHealth : HealthComponent
    {
        private StringEventChannel _onEnemyDeath;
        private EnemyId _enemyId;

        protected override void HandleDeath()
        {
            _onEnemyDeath.Raise(_enemyId.ID);
        }

        private void Awake()
        {
            _onEnemyDeath = GameEvents.OnEnemyDeath;
            _enemyId = GetComponent<EnemyId>();
        }
    }
}