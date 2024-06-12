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
        [SerializeField] private LayerMask _takeableItemLayerMask;
        public float Speed => _speed;
        public float RayRange => _rayRange;
        public LayerMask InteractableLayer => _interactableLayerMask;
        public LayerMask TakeableItemLayer => _takeableItemLayerMask;
    }
}
