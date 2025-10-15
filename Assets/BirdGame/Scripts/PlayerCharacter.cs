using UnityEngine;

namespace BirdGame
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerCharacter : MonoBehaviour
    {
        private const string JumpKey = "Jump";
        private readonly Vector3 UpDirection = Vector3.up;
        private readonly Vector3 LeftDirection = Vector3.up + Vector3.left;
        private readonly Vector3 RightDirection = Vector3.up + Vector3.right;

        [SerializeField] private float _jumpForce = 5;
        [SerializeField] private ParticleSystem _jumpEffect = null;
        [SerializeField] private Animator _playerAnimator = null;

        [SerializeField] private KeyCode _upKey = KeyCode.W;
        [SerializeField] private KeyCode _leftKey = KeyCode.A;
        [SerializeField] private KeyCode _rightKey = KeyCode.D;

        private Rigidbody _rigidbody = null;

        public int OrdinaryJumpCount { get; private set; } = 0;
        public int SideJumpCount { get; private set; } = 0;

        private void Awake()
            => _rigidbody = GetComponent<Rigidbody>();

        private void Update()
        {
            if (Input.GetKeyDown(_upKey))
                UpJump(UpDirection);

            if (Input.GetKeyDown(_leftKey))
                SideJump(LeftDirection);

            if (Input.GetKeyDown(_rightKey))
                SideJump(RightDirection);
        }

        public void Init(Vector3 position)
        {
            OrdinaryJumpCount = 0;
            SideJumpCount = 0;
            
            _rigidbody.velocity = Vector3.zero;
            transform.position = position;

            gameObject.SetActive(true);
        }
 
        public void GameOver()
            => gameObject.SetActive(false);

        private void Jump(Vector3 jumpDirection)
        {
            _rigidbody.AddForce(jumpDirection * _jumpForce, ForceMode.Impulse);

            _jumpEffect.Play();

            _playerAnimator.SetTrigger(JumpKey);
        }

        private void UpJump(Vector3 jumpDirection)
        {
            OrdinaryJumpCount++;

            Jump(jumpDirection);
        }

        private void SideJump(Vector3 jumpDirection)
        {
            SideJumpCount++;

            Jump(jumpDirection);
        }
    }
}