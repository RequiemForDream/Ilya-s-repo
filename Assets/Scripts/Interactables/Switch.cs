using UnityEngine;

namespace Interactables
{
    public class Switch : Interactable
    {
        [SerializeField] private Transform _switchPanel;
        [SerializeField] private Quaternion _turnOffRotation;
        [SerializeField] private Quaternion _turnOnRotation;

        private bool _isTurnedOn = true;

        public override void Interact()
        {
            if (_isTurnedOn)
            {
                _isTurnedOn = false;
                _switchPanel.localRotation = _turnOffRotation;
            }
            else
            {
                _isTurnedOn = true;
                _switchPanel.localRotation = _turnOnRotation;
            }
        }
    }
}
