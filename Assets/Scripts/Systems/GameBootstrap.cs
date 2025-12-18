using Databases;
using Events;
using UnityEngine;
using UnityEngine.UIElements;

namespace Systems
{
    public class GameBootstrap : MonoBehaviour
    {
        [Header("Player Events")] 
        [SerializeField] private IntEventChannel onPlayerDamaged;
        [SerializeField] private IntEventChannel onGoldChanged;
        [SerializeField] private IntEventChannel onExperienceChanged;
        [SerializeField] private IntEventChannel onLevelChanged;
        
        [Header("Audio Events")]
        [SerializeField] private StringEventChannel onMusicRequested;
        [SerializeField] private StringEventChannel onSfxRequested;
        
        [Header("Databases")]
        [SerializeField] private AudioClipDatabase audioDatabase;
        [SerializeField] private WeaponDatabase weaponDatabase;
        
        [Header("UI Toolkit")]
        [SerializeField] private StyleSheet styleSheet;

        private void Awake()
        {
            GameEvents.OnPlayerDamaged =  onPlayerDamaged;
            GameEvents.OnGoldChanged =  onGoldChanged;
            GameEvents.OnExperienceGained =  onExperienceChanged;
            GameEvents.OnLevelChanged =  onLevelChanged;
            
            GameEvents.OnMusicRequested = onMusicRequested;
            GameEvents.OnSfxRequested = onSfxRequested;
            
            GameDatabases.AudioClipDatabase =  audioDatabase;
            GameDatabases.WeaponDatabase = weaponDatabase;
        }
    }
}
