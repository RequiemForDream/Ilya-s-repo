using System.Collections;
using UnityEngine;

namespace Interactables
{
    public class Crane : Interactable
    {
        [SerializeField] private GameObject _waterPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private AudioSource _craneSource;

        public override void Interact()
        {
            base.Interact();
            if (_isInteracted)
            {
                StartCoroutine(WaterRoutine());
                _craneSource.Play();
            }
            else
            {
                StopCoroutine(WaterRoutine());
                _craneSource.Stop();
            }
        }

        private IEnumerator WaterRoutine()
        {
            while (_isInteracted)
            {
                var water = Instantiate(_waterPrefab, _spawnPoint.transform.position, Quaternion.identity);
                Destroy(water, 0.4f);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
