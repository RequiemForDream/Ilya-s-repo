using System;
using UnityEngine;

namespace Character
{
    [Serializable]
    public struct CharacterModel
    {
        [Header("Interactable Parametrs")]
        [SerializeField] private float _speed;
        [SerializeField] private float _rayRange;
        [SerializeField] private LayerMask _interactableLayerMask;

        [Header("Takeable parametrs")]
        [SerializeField] private float _takeRange;
        [SerializeField] private LayerMask _takeableItemLayerMask;

        public float Speed => _speed;
        public float RayRange => _rayRange;
        public float TakeRange => _takeRange;
        public LayerMask InteractableLayer => _interactableLayerMask;
        public LayerMask TakeableItemLayer => _takeableItemLayerMask;
    }
}
