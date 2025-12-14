using Databases;
using Events;
using UnityEngine;

namespace Systems
{
    public class GameBootstrap : MonoBehaviour
    {
        [Header("Player Events")] 
        [SerializeField] private IntEventChannel onPlayerDamaged;
        
        [Header("Audio Events")]
        [SerializeField] private StringEventChannel onMusicRequested;
        [SerializeField] private StringEventChannel onSfxRequested;
        
        [Header("Databases")]
        [SerializeField] private AudioClipDatabase audioDatabase;
        [SerializeField] private TMPFontDatabase fontDatabase;
        [SerializeField] private SpriteDatabase spriteDatabase;

        private void Awake()
        {
            GameEvents.OnPlayerDamaged =  onPlayerDamaged;
            GameEvents.OnMusicRequested = onMusicRequested;
            GameEvents.OnSfxRequested = onSfxRequested;
            
            GameDatabases.AudioClipDatabase =  audioDatabase;
            GameDatabases.TMPFontDatabase =  fontDatabase;
            GameDatabases.SpriteDatabase =  spriteDatabase;
        }
    }
}
