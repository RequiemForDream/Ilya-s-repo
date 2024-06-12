using UnityEngine;

namespace Interactables
{
    public class Switch : Interactable
    {
        [SerializeField] private Transform _switchPanel;
        [SerializeField] private Light[] _lights;
        [SerializeField] private Vector3 _turnOffRotation;
        [SerializeField] private Vector3 _turnOnRotation;

        private bool _isTurnedOn = true;

        public override void Interact()
        {
            if (_isTurnedOn)
            {
                _isTurnedOn = false;
                _switchPanel.eulerAngles = _turnOffRotation;
                foreach (var light in _lights)
                {
                    light.gameObject.SetActive(false);
                } 
            }
            else if (!_isTurnedOn)
            {
                _isTurnedOn = true;
                _switchPanel.eulerAngles = _turnOnRotation;
                foreach (var light in _lights)
                {
                    light.gameObject.SetActive(true);
                }
            }
        }
    }
}
