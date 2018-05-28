using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlendShapesAnimations
{
    public class SimpleIK : MonoBehaviour
    {
        [SerializeField] private Transform _lookTarget;

        [SerializeField] [Range(0.0f, 1.0f)] private float _weight;
        [SerializeField] [Range(0.0f, 1.0f)] private float _bodyWeight;
        [SerializeField] [Range(0.0f, 1.0f)] private float _headWeight;
        [SerializeField] [Range(0.0f, 1.0f)] private float _eyesWeight;
        [SerializeField] [Range(0.0f, 1.0f)] private float _clampWeight;

        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnAnimatorIK(int layerIndex)
        {
            _animator.SetLookAtPosition(_lookTarget.position);
            _animator.SetLookAtWeight(_weight, _bodyWeight, _headWeight, _eyesWeight, _clampWeight);
        }
    }
}
