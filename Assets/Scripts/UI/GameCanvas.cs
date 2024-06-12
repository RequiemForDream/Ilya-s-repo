using Interactables;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _interactableText;
        [SerializeField] private GameObject _takeableText;
        [SerializeField] private GameObject _takenText;
        
        public GameObject InteractableText => _interactableText;
        public GameObject TakeableText => _takeableText;
        public GameObject TakenText => _takenText;
    }
}
