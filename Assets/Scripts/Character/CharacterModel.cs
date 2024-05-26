using System;
using UnityEngine;

namespace Character
{
    [Serializable]
    public struct CharacterModel
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rayRange;
        [SerializeField] private LayerMask _interactableLayerMask;
        public float Speed => _speed;
        public float RayRange => _rayRange;
        public LayerMask InteractableLayer => _interactableLayerMask;
    }
}
