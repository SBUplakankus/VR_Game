using System;
using Constants;
using Databases;
using UnityEngine;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {
        [Header("Audio Sources")] 
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource masterSource;
        
        [Header("Audio Database")]
        private AudioClipDatabase _audioDatabase;

        private void OnEnable()
        {
            _audioDatabase = GameDatabases.AudioClipDatabase;
            PlayMusic();
        }

        private void PlayMusic()
        {
            musicSource.clip = _audioDatabase.TryGet(GameConstants.MainMusicKey).clip;
            musicSource.Play();
        }

        private AudioClip TryGet(string key)
        {
            if (_audioDatabase == null)
            {
                Debug.LogError($"Audio Database is NULL");
                return null;
            }
            
            return _audioDatabase.TryGet(key).clip;
        }
    }
}
