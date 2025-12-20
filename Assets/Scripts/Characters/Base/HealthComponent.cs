using UnityEngine;

namespace Characters.Base
{
    public abstract class HealthComponent : MonoBehaviour
    {
        private int _currentHealth;
        private int _maxHealth;

        public void InitHealth(int maxHealth)
        {
            _currentHealth = maxHealth;
            _maxHealth = maxHealth;
        }

        public void ResetHealth() => _currentHealth = _maxHealth;
        
        protected abstract void HandleDeath();
        
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
                HandleDeath();
        }
    }
}