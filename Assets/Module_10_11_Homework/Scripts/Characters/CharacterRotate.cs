using UnityEngine;

namespace Module_10_11_Homework.Characters
{
    public class CharacterRotate : MonoBehaviour
    {
        [SerializeField] private float _speed = 650f;
        private Quaternion _initialRotation = Quaternion.identity;

        private void Awake()
        {
            _initialRotation = gameObject.transform.rotation;
        }

        public void Rotate(Vector3 direction)
        {
            Vector3 normalizeDirection = direction.normalized;

            Quaternion targetRotate = Quaternion.LookRotation(normalizeDirection);

            float delta = _speed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotate, delta);
        }

        public void Reset()
            => gameObject.transform.rotation = _initialRotation;
    }
}