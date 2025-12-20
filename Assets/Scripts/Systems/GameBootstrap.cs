using Databases;
using Events;
using UnityEngine;
using UnityEngine.UIElements;

namespace Systems
{
    public class GameBootstrap : MonoBehaviour
    {
        #region Fields
        
        [Header("Player Events")] 
        [SerializeField] private IntEventChannel onPlayerDamaged;
        [SerializeField] private IntEventChannel onGoldChanged;
        [SerializeField] private IntEventChannel onExperienceChanged;
        [SerializeField] private IntEventChannel onLevelChanged;

        [Header("Game Events")] 
        [SerializeField] private StringEventChannel onEnemyDeath;
        
        [Header("Audio Events")]
        [SerializeField] private StringEventChannel onMusicRequested;
        [SerializeField] private StringEventChannel onSfxRequested;
        
        [Header("Databases")]
        [SerializeField] private AudioClipDatabase audioDatabase;
        [SerializeField] private WeaponDatabase weaponDatabase;
        [SerializeField] private EnemyDatabase enemyDatabase;
        
        [Header("UI Toolkit")]
        [SerializeField] private StyleSheet styleSheet;

        #endregion
        
        #region Class Methods
        
        private void SetPlayerEvents()
        {
            GameEvents.OnPlayerDamaged =  onPlayerDamaged;
            GameEvents.OnGoldChanged =  onGoldChanged;
            GameEvents.OnExperienceGained =  onExperienceChanged;
            GameEvents.OnLevelChanged =  onLevelChanged;
        }

        private void SetGameEvents()
        {
            GameEvents.OnEnemyDeath = onEnemyDeath;
        }

        private void SetAudioEvents()
        {
            GameEvents.OnMusicRequested = onMusicRequested;
            GameEvents.OnSfxRequested = onSfxRequested;
        }

        private void SetDatabases()
        {
            GameDatabases.AudioClipDatabase =  audioDatabase;
            GameDatabases.WeaponDatabase = weaponDatabase;
            GameDatabases.EnemyDatabase = enemyDatabase;
        }
        
        #endregion
        
        #region Unity Methods
        
        private void Awake()
        {
            SetPlayerEvents();
            SetGameEvents();
            SetAudioEvents();
            SetDatabases();
        }
        
        #endregion
    }
}
