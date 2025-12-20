using UnityEngine;

namespace Characters.Enemies
{
    [RequireComponent(typeof(EnemyHealth), typeof(EnemyId), typeof(EnemyMovement))]
    public class EnemyController : MonoBehaviour
    {
        #region Fields

        [Header("Components")] 
        private EnemyMovement _enemyMovement;
        private EnemyHealth _enemyHealth;
        private EnemyId _enemyId;

        #endregion
        
        #region Class Functions

        public void Initialise()
        {
            
        }
        
        #endregion
        
        #region Unity Functions

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyHealth = GetComponent<EnemyHealth>();
            _enemyId = GetComponent<EnemyId>();
        }
        
        #endregion
    }
}
