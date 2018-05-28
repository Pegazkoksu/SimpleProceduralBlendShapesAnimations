using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlendShapesAnimations
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _audioClips;
        [SerializeField] private bool _stopOnEnd;

        [Header("Amplitude Capture Settings")]

        [SerializeField] [Range(8, 128)] private uint _sampleDataLength = 32;
        [SerializeField] [Range(10, 500)] private float _loudnessMultiplier = 128;

        private float _clipLoudness;
        private float[] _clipSampleData;

        private AudioSource _audioSource;

        public AudioSource AudioSource
        {
            get { return _audioSource; }
        }

        private uint _index;

        private void Start()
        {
            _audioSource = GetComponentInChildren<AudioSource>();
            _clipSampleData = new float[_sampleDataLength];

            AssignNewClip();
        }

        private void Update()
        {
            UpdateAudioClips();
        }

        void UpdateAudioClips()
        {
            if (_index >= _audioClips.Length - 1 && _stopOnEnd)
            {
                return;
            }

            if (!_audioSource.isPlaying || Input.GetKeyDown(KeyCode.R))
            {
                if (_index < _audioClips.Length - 1)
                {
                    _index++;
                }
                else if (!_stopOnEnd)
                {
                    _index = 0;
                }

                AssignNewClip();
            }
        }

        void AssignNewClip()
        {
            _audioSource.clip = _audioClips[_index];
            _audioSource.Play();
        }

        public float GetSoundAmplitude()
        {
            if (!_audioSource.isPlaying)
                return 0;

            _audioSource.clip.GetData(_clipSampleData, _audioSource.timeSamples);
            _clipLoudness = 0.0f;

            foreach (var sample in _clipSampleData)
            {
                _clipLoudness += Mathf.Abs(sample);
            }

            _clipLoudness /= _sampleDataLength;
            _clipLoudness *= _loudnessMultiplier;

            return _clipLoudness;
        }
    }
}
