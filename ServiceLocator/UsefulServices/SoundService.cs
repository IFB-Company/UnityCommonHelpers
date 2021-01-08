using System;
using Common.ServiceLocator;
using UnityEngine;
using UnityEngine.Assertions;

namespace UnityCommonHelpers.ServiceLocator.UsefulServices
{
    public class SoundService : MonoBehaviour, IGameService
    {
        [SerializeField] private AudioSource _soundSource;
        [SerializeField] private AudioSource _musicSource;

        private void Awake()
        {
            Assert.IsNotNull(_soundSource, "_soundSource != null");
            Assert.IsNotNull(_musicSource, "_musicSource != null");
        }


        public void SetSoundVolume(float volume)
        {
            SetSourceVolume(_soundSource, volume);
        }
        
        public void SetMusicVolume(float volume)
        {
            SetSourceVolume(_musicSource, volume);
        }
        
        private void SetSourceVolume(AudioSource source, float volume)
        {
            if (source != null)
            {
                source.volume = volume;
            }
        }

        public void MuteSound()
        {
            MuteSource(_soundSource);
        }

        public void MuteMusic()
        {
            MuteSource(_musicSource);
        }

        private void MuteSource(AudioSource audioSource)
        {
            if (audioSource != null)
            {
                audioSource.mute = true;
            }
        }

        public void PlaySound(AudioClip audioClip)
        {
            if (_soundSource != null)
            {
                _soundSource.PlayOneShot(audioClip);
            }
        }

        public void PlayMusic(AudioClip audioClip, bool isLoop = true)
        {
            if (_musicSource != null)
            {
                _musicSource.loop = isLoop;
                _musicSource.clip = audioClip;
                _musicSource.Play();
            }
        }
    }
}
