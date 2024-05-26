using Core.Interfaces;
using System;
using UnityEngine;

namespace Core
{
    public class InputService : IInputService, IUpdateListener
    {
        public event Action<Vector3> OnMove;
        public event Action<Vector2> OnMouseLook;
        public event Action OnLeftMouseButtonDown;
        public event Action OnInteractBtnTap;

        private readonly Updater _updater;

        private float _axisY;
        private float _axisX;

        public InputService(Updater updater)
        {
            _updater = updater;
            _updater.AddListener(this);
        }

        public void Tick(float deltaTime)
        {
            ClampAxis();
            GetAxis();
            Move();
            ReadInteract();
        }

        private void Move()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var direction = new Vector3(horizontal, 0f, vertical);
            OnMove?.Invoke(direction);
        }

        private void ClampAxis()
        {
            _axisX += Input.GetAxis("Mouse X");
            _axisY -= Input.GetAxis("Mouse Y");

            var look = new Vector2(_axisX, _axisY);
            OnMouseLook?.Invoke(look);
        }

        private void ReadInteract()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnInteractBtnTap?.Invoke();
            }
        }

        private void GetAxis()
        {
            _axisY = Mathf.Clamp(_axisY, -86f, 75f);
        }
    }
}