using UnityEngine;

namespace Interactables
{
    public abstract class Interactable : MonoBehaviour, IInteractable, ITakeable
    {
        protected bool _isInteracted;

        public virtual void Start()
        {
            
        }

        public virtual void Interact()
        {
            _isInteracted = !_isInteracted;
        }

        public virtual void Take()
        {
            
        }
    }
}
