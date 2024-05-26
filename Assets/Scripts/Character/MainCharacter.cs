using Core;
using Core.Interfaces;
using Interactables;
using UnityEngine;

namespace Character
{
    public class MainCharacter : IUpdateListener
    {
        public readonly CharacterView _characterView;
        private readonly CharacterModel _characterModel;
        private readonly Updater _updater;
        private readonly IInputService _inputService;

        private Quaternion _startTransformRotation;

        public MainCharacter(CharacterView characterView, CharacterModel characterModel, Updater updater, IInputService inputService)
        {
            this._characterView = characterView;
            _characterModel = characterModel;
            _updater = updater;
            _inputService = inputService;
        }

        public void Initialize()
        {
            _startTransformRotation = _characterView.Head.transform.rotation;
            _updater.AddListener(this);
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _characterView.OnDestroyHandler += Destroy;
            _inputService.OnMouseLook += OnMouseLook;
            _inputService.OnMove += OnMoveInput;
            _inputService.OnInteractBtnTap += TryToInteract;
        }

        private void TryToInteract()
        {
            var ray = new Ray(_characterView.MainCamera.transform.position, _characterView.MainCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _characterModel.RayRange, _characterModel.InteractableLayer))
            {
                if (hitInfo.collider.TryGetComponent(out Interactable interactable))
                {
                    interactable.Interact();
                }
            }
        }

        private void OnMouseLook(Vector2 mouseLook)
        {
            var rotateX =
                Quaternion.AngleAxis(mouseLook.x, Vector3.up * Time.deltaTime * 1);
            var rotateY =
                Quaternion.AngleAxis(mouseLook.y, Vector3.right * Time.deltaTime * 1);

            _characterView.transform.rotation = _startTransformRotation * rotateX;
            _characterView.Head.transform.rotation = _characterView.transform.rotation * rotateY;
        }

        private void OnMoveInput(Vector3 direction)
        {
            var transform = _characterView.transform;
            var rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);
            _characterView.CharacterController.Move(rawDirection * _characterModel.Speed * Time.deltaTime);
        }

        public void Tick(float deltaTime)
        {
            
        }

        private void Destroy()
        {
            _updater.RemoveListener(this);
            _characterView.OnDestroyHandler -= Destroy;
            _inputService.OnMouseLook -= OnMouseLook;
            _inputService.OnMove -= OnMoveInput;
        }
    }
}
