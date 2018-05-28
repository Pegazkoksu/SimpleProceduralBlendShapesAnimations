using UnityEngine;
using System.Collections;

namespace BlendShapesAnimations
{
    [System.Serializable]
    public class BlendShapeObject
    {
        [SerializeField] private int _index;
        [SerializeField] private float _multiplier = 1.0f;

        public int Index
        {
            get { return _index; }
        }

        public float Multiplier
        {
            get { return _multiplier; }
        }
    }
}
