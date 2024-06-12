using UnityEngine;

namespace Interactables
{
    public class Takeable : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _clip;
        public Rigidbody Rigidbody { get; private set; }

        private bool _isThrowed;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        public void ThrowItem()
        {
            transform.parent = null;
            Rigidbody.isKinematic = false;
            Rigidbody.AddForce(Camera.main.transform.forward * 5, ForceMode.Impulse);
            _isThrowed = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_isThrowed)
            {
                _source.PlayOneShot(_clip);
                Destroy(gameObject);
                Debug.Log("FFFFF");
            }
        }
    }
}
