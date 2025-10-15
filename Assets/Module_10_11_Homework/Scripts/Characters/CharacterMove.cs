using UnityEngine;

namespace Module_10_11_Homework.Characters
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float _speed = 5f;
        private CharacterController _characterController = null;
        private Vector3 _initialPosition = Vector3.zero;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();

            _initialPosition = gameObject.transform.position;
        }

        public void Move(Vector3 direction)
        {
            Vector3 normalizeDirection = direction.normalized;
            _characterController.Move(normalizeDirection * _speed * Time.deltaTime);
        }

        public void Reset()
        {
            _characterController.enabled = false;

            gameObject.transform.position = _initialPosition;

            _characterController.enabled = true;
        }
    }
}