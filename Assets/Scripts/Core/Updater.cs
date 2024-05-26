using Core.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Updater : MonoBehaviour
    {
        private List<IUpdateListener> _updateListeners = new List<IUpdateListener>();
        private List<IFixedUpdateListener> _fixedUpdateListeners = new List<IFixedUpdateListener>();

        private void Update()
        {
            foreach (var listener in _updateListeners)
            {
                listener.Tick(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            foreach (var listener in _fixedUpdateListeners)
            {
                listener.FixedTick(Time.fixedDeltaTime);
            }
        }

        public void AddListener(IUpdateListener listener)
        {
            _updateListeners.Add(listener);
        }

        public void RemoveListener(IUpdateListener listener)
        {
            _updateListeners.Remove(listener);
        }

        public void RemoveFixedUpdateListener(IFixedUpdateListener listener)
        {
            _fixedUpdateListeners.Remove(listener);
        }

        public void AddFixedUpdateListener(IFixedUpdateListener listener)
        {
            _fixedUpdateListeners.Add(listener);
        }
    }
}