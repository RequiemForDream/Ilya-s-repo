using UnityEngine;

namespace Interactables
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        protected bool _isInteracted;

        public virtual void Interact()
        {
            _isInteracted = !_isInteracted;
        }
    }
}
