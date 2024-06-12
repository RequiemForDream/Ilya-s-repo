using DG.Tweening;
using UnityEngine;

namespace Interactables
{
    public class ClosetDoor : Interactable
    {
        [SerializeField] private Vector3 _openedRotation;
        [SerializeField] private Vector3 _closedRotation;

        private bool _isOpened;

        public override void Interact()
        {
            if (_isOpened)
            {
                transform.DORotate(_closedRotation, 0.5f, RotateMode.Fast);
                _isOpened = false;
            }
            else
            {
                transform.DORotate(_openedRotation, 0.5f, RotateMode.Fast);
                _isOpened = true;
            }
        }
    }
}
