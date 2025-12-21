using UnityEngine;

namespace Characters.Base
{
    public abstract class HealthComponent : MonoBehaviour
    {
        private int _currentHealth;
        private int _maxHealth;
        
        /// <summary>
        /// Initialise the Health Component
        /// </summary>
        /// <param name="maxHealth">Max Health</param>
        public void InitHealth(int maxHealth)
        {
            _currentHealth = maxHealth;
            _maxHealth = maxHealth;
        }

        public void ResetHealth() => _currentHealth = _maxHealth;
        
        protected abstract void HandleDeath();
        
        /// <summary>
        /// Damage the health component and check to see if dead
        /// </summary>
        /// <param name="damage">Damage to be done</param>
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
                HandleDeath();
        }
    }
}