using Databases;
using UnityEngine;

namespace Characters.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        #region Fields

        [Header("Components")] 
        private EnemyMovement _enemyMovement;
        private EnemyAnimator _enemyAnimator;
        private EnemyAttack _enemyAttack;
        private EnemyHealth _enemyHealth;
        private EnemyData _enemyData;
        private EnemyId _enemyId;

        #endregion
        
        #region Class Functions
        
        public void Initialise(string id)
        {
            _enemyData = GameDatabases.EnemyDatabase.Get(id);
            
            _enemyId.ID = _enemyData.EnemyId;
            _enemyHealth.InitHealth(_enemyData.MaxHealth);
            _enemyMovement.InitMovement(_enemyData.MoveSpeed);
            _enemyAttack.InitAttack(10, 2);
            _enemyAnimator.InitAnimator();
        }

        public void Reset()
        {
            
        }
    
        private void ValidateRequiredComponents()
        {
            if (!GetComponent<EnemyHealth>())
                gameObject.AddComponent<EnemyHealth>();
            
            if (!GetComponent<EnemyId>())
                gameObject.AddComponent<EnemyId>();
            
            if (!GetComponent<EnemyMovement>())
                gameObject.AddComponent<EnemyMovement>();
            
            if (!GetComponent<EnemyAttack>())
                gameObject.AddComponent<EnemyAttack>();
            
            if (!GetComponent<EnemyAnimator>())
                gameObject.AddComponent<EnemyAnimator>();
        }
    
        private void CacheComponents()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
            _enemyId = GetComponent<EnemyId>();
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyAttack = GetComponent<EnemyAttack>();
            _enemyAnimator = GetComponent<EnemyAnimator>();
        }
        
        #endregion
        
        #region Unity Functions

        private void Awake()
        {
            ValidateRequiredComponents();
            CacheComponents();
        }
        
        #endregion
    }
}
