using UnityEngine;
using Module_10_11_Homework.Inputs;

namespace Module_10_11_Homework.Characters
{
    [RequireComponent(typeof(CharacterMove), typeof(CharacterRotate))]
    public abstract class Character : MonoBehaviour
    {
        private const string _speedKey = "Speed";
        [SerializeField, Range(0.05f, 0.95f)] private float _moveDeadzone = 0.05f;
        [SerializeField] private Animator _animator = null;
        private CharacterMove _characterMove = null;
        private CharacterRotate _characterRotate = null;
        protected IInput input = null;
        private bool _isGameRunning = false;
        private void Awake()
        {
            _characterMove = GetComponent<CharacterMove>();
            _characterRotate = GetComponent<CharacterRotate>();

            InitInput();

        }

        private void Start()
        {
            Reset();
        }

        private void Update()
        {
            if (_isGameRunning == false)
                return;

            Vector3 moveDirection = input.MoveAxes;
            float directionMagnitude = moveDirection.sqrMagnitude;

            _animator.SetFloat(_speedKey, directionMagnitude);

            if (directionMagnitude <= _moveDeadzone)
                return;

            _characterMove.Move(moveDirection);
            _characterRotate.Rotate(moveDirection);
        }

        protected abstract void InitInput();

        public void Reset()
        {
            if (gameObject.activeInHierarchy == false)
                gameObject.SetActive(true);

            _isGameRunning = true;

            _characterMove.Reset();
            _characterRotate.Reset();
        }
    }
}