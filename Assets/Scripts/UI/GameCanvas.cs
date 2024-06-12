using TMPro;
using UnityEngine;

namespace UI
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _interactableText;
        
        public GameObject InteractableText => _interactableText;
    }
}
