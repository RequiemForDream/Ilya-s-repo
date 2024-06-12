using Core.Interfaces;
using System;
using UnityEngine;

namespace Character
{
    public class CharacterView : MonoBehaviour, IDestroyable
    {
        public event Action OnDestroyHandler;

        public Transform Head;
        public Transform MainCamera;
        public Transform TakenObjectPosition;
        public CharacterController CharacterController;

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}
