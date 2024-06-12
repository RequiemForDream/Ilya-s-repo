using Core;
using Core.Interfaces;
using Interactables;
using UI;
using UnityEngine;

namespace Character
{
    public class MainCharacter : IUpdateListener
    {
        public readonly CharacterView _characterView;
        private readonly CharacterModel _characterModel;
        private readonly Updater _updater;
        private readonly IInputService _inputService;
        private readonly GameCanvas _gameCanvas;

        private Quaternion _startTransformRotation;
        private bool _isTaken;
        private Takeable _currentItem = null;

        public MainCharacter(CharacterView characterView, CharacterModel characterModel, Updater updater, IInputService inputService,
            GameCanvas gameCanvas)
        {
            this._characterView = characterView;
            _characterModel = characterModel;
            _updater = updater;
            _inputService = inputService;
            _gameCanvas = gameCanvas;
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
            _inputService.OnTakeItemBtnTap += TryToTakeItem;
            _inputService.OnThrowItemBtnTap += ThrowObject;
        }

        private void TryToInteract()
        {
            var ray = new Ray(_characterView.MainCamera.transform.position, _characterView.MainCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _characterModel.RayRange, _characterModel.InteractableLayer))
            {
                if (hitInfo.collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }

        private void TryToTakeItem()
        {
            var ray = new Ray(_characterView.MainCamera.transform.position, _characterView.MainCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _characterModel.TakeRange, _characterModel.TakeableItemLayer))
            {
                Debug.Log("Take");
                if (!_isTaken)
                {
                    if (hitInfo.collider.TryGetComponent(out Takeable takeable))
                    {
                        takeable.Rigidbody.isKinematic = true;
                        takeable.transform.parent = _characterView.transform;
                        takeable.transform.position = _characterView.TakenObjectPosition.position;
                        _isTaken = true;
                        _currentItem = takeable;
                    }
                }
            }
        }

        private void ThrowObject()
        {
            if (_currentItem != null)
            {
                _currentItem.ThrowItem();
                _currentItem = null;
                _isTaken = false;
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
            var ray = new Ray(_characterView.MainCamera.transform.position, _characterView.MainCamera.transform.forward);

            if (_isTaken)
            {
                _gameCanvas.TakenText.SetActive(true);
                _gameCanvas.InteractableText.SetActive(false);
                _gameCanvas.TakeableText.SetActive(false);
            }
            else
            {
                _gameCanvas.TakenText.SetActive(false);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, _characterModel.RayRange, _characterModel.InteractableLayer))
                {
                    _gameCanvas.InteractableText.SetActive(true);
                    _gameCanvas.TakeableText.SetActive(false);
                }
                else
                {
                    _gameCanvas.InteractableText.SetActive(false);
                }

                if (Physics.Raycast(ray, out RaycastHit hit, _characterModel.TakeRange, _characterModel.TakeableItemLayer))
                {
                    _gameCanvas.TakeableText.SetActive(true);
                    _gameCanvas.InteractableText.SetActive(false);
                }
                else
                {
                    _gameCanvas.TakeableText.SetActive(false);
                }
            }
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
