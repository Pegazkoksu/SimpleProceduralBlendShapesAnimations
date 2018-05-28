using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlendShapesAnimations
{
    [RequireComponent(typeof(AudioManager))]
    public class BlendShapeController : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _mesh;

        [SerializeField] private BlendShapeObject[] _blendShapeObjects;
        [SerializeField] private float _lerpSpeed = 10.0f;


        private AudioManager _audioManager;
        private float _weight, _targetWeight;

        private void Start()
        {
            GetReferences();
        }

        private void GetReferences()
        {
            _audioManager = GetComponent<AudioManager>();
        }

        private void Update()
        {
            ConvertFromAudioToBlendShapes();
        }

        private void ConvertFromAudioToBlendShapes()
        {
            _targetWeight = _audioManager.GetSoundAmplitude();
            _weight = Mathf.Lerp(_weight, _targetWeight, Time.deltaTime * _lerpSpeed);

            foreach (var blendShape in _blendShapeObjects)
            {
                _mesh.SetBlendShapeWeight(blendShape.Index, _weight * blendShape.Multiplier);
            }
        }
    }
}
