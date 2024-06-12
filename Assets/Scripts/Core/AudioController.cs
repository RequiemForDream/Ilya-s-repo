using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private float _timeBetweenSounds = 10f;

        [Header("Audio Sources")]
        [SerializeField] private AudioSource _doorAudio;
        [SerializeField] private AudioSource _weatherSound;

        [Header("AudioClip")]
        [SerializeField] private AudioClip _doorSound;
        [SerializeField] private AudioClip _weatherAudio;

        private float _currentTime = 0;

        private AudioSource[] _sources => new AudioSource[] {_doorAudio, _weatherSound};

        private void Start()
        {
            _currentTime = _timeBetweenSounds;
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime < 0f)
            {
                var index = Random.Range(0, _sources.Length);

                if (_sources[index] == _doorAudio)
                {
                    _doorAudio.PlayOneShot(_doorSound);
                }
                else
                {
                    _sources[index].PlayOneShot(_weatherAudio);
                }

                _currentTime = _timeBetweenSounds;
            }
        }
    }
}