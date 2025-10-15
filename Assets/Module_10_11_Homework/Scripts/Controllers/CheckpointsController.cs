using UnityEngine;

namespace Module_10_11_Homework.Controllers
{
    public class CheckpointsController : MonoBehaviour
    {
        [SerializeField] private GameObject _pointPrefab = null;
        [SerializeField] private Transform[] _checkpoints = null;
        public Vector3 CurrentCheckpointPosition { get; private set; } = Vector3.zero;
        private GameObject _prefabInstance = null;

        public void NextRandomCheckpointPosition()
        {
            int randomIndex = Random.Range(0, _checkpoints.Length);
            CurrentCheckpointPosition = _checkpoints[randomIndex].position;

            if (_prefabInstance == null)
                _prefabInstance = Instantiate(_pointPrefab);

            _prefabInstance.transform.position = CurrentCheckpointPosition;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(CurrentCheckpointPosition, 0.5f);
        }
#endif
    }
}