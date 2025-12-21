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
        [SerializeField] private AudioSource sfxSource;
        
        [Header("Audio Database")]
        private AudioClipDatabase _audioDatabase;

        private void OnEnable()
        {
            _audioDatabase = GameDatabases.AudioClipDatabase;
            PlayMusic();
        }

        private void PlayMusic()
        {
            musicSource.clip = GetClip(GameConstants.MainMusicKey);
            musicSource.Play();
        }

        public void PlaySfx(string key)
        {
            var sfx = GetClip(key);
            if (sfx == null) return;
            sfxSource.PlayOneShot(sfx);
        }

        private AudioClip GetClip(string key) =>  _audioDatabase.Get(key).clip;
    }
}
