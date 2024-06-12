using UnityEngine;

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

        private void Start()
        {
            _currentTime = _timeBetweenSounds;
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime < 0 )
            {

            }
        }
    }
}