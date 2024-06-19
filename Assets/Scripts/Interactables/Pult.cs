using UnityEngine;

namespace Interactables
{
    public class Pult : Interactable
    {
        [SerializeField] private AudioSource _tvSource;
        [SerializeField] private AudioSource _pultBtn;
        [SerializeField] private AudioClip _clickClip;

        [Header("Materials")]
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _turnOffMaterial;
        [SerializeField] private Material _turnOnMaterial;

        private bool _isTurnedOn = false;

        public override void Interact()
        {
           _isTurnedOn = !_isTurnedOn;

            _pultBtn.PlayOneShot(_clickClip);
            if (_isTurnedOn)
            {
                _tvSource.Play();
                _meshRenderer.material = _turnOnMaterial;
            }
            else
            {
                _meshRenderer.material = _turnOffMaterial;
                _tvSource.Stop();
            }
        }
    }
}
