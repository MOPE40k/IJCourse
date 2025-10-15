using UnityEngine;
using Module_10_11_Homework.Characters;
using Module_10_11_Homework.Utils;

namespace Module_10_11_Homework.Controllers
{
    public class GameController : MonoBehaviour
    {
        private const string GameOverMessage = "Game Over!";
        private const string WonMessage = "You WON!";
        [SerializeField] private PlayerCharacter _player = null;
        [SerializeField] private PartnerCharacter _partner = null;
        [SerializeField] private SpriteRenderer _distanceVisibleArea = null;
        [SerializeField] private Color _closeCondition = Color.green;
        [SerializeField] private Color _farCondition = Color.red;
        [SerializeField] private float _distanceThreshold = 3f;
        [SerializeField] private float _gameOverConditionValue = 15f;
        [SerializeField] private float _wonConditionValue = 10f;
        [SerializeField] private KeyCode _restartKey = KeyCode.R;
        private DistanceChecker _distanceChecker = null;
        private Timer _gameOverTimer = null;
        private Timer _winTimer = null;
        private bool _gameIsRunning = false;

        private void Awake()
        {
            _distanceChecker = new DistanceChecker(_distanceThreshold);

            _gameOverTimer = new Timer();
            _winTimer = new Timer();
        }

        private void Start()
        {
            Reset();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(_restartKey))
            {
                Reset();
            }
        }

        private void FixedUpdate()
        {
            if (_gameIsRunning == false)
                return;

            if (IsCloseTo())
            {
                _gameOverTimer.Decrement(Time.fixedDeltaTime);
                _winTimer.Increment(Time.fixedDeltaTime);

                _distanceVisibleArea.color = _closeCondition;
            }
            else
            {
                _winTimer.Decrement(Time.fixedDeltaTime);
                _gameOverTimer.Increment(Time.fixedDeltaTime);

                _distanceVisibleArea.color = _farCondition;
            }

            if (IsGameOver())
                GameOver();

            if (IsWon())
                Win();
        }

        private bool IsCloseTo()
            => _distanceChecker.CheckDistance(_player.transform.position, _partner.transform.position);

        private void GameEnd(string message)
        {
            _player.gameObject.SetActive(false);
            _partner.gameObject.SetActive(false);

            Debug.Log($"{message} Press {_restartKey} to RESTART!");
        }

        private bool IsGameOver()
            => _gameOverTimer.Time >= _gameOverConditionValue;

        private void GameOver()
        {
            GameEnd(GameOverMessage);
        }

        private bool IsWon()
            => _winTimer.Time >= _wonConditionValue;

        private void Win()
        {
            GameEnd(WonMessage);
        }

        private void Reset()
        {
            _player.Reset();
            _partner.Reset();

            _gameOverTimer.Reset();
            _winTimer.Reset();

            _gameIsRunning = true;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (_distanceChecker is null)
                return;

            Gizmos.color = IsCloseTo() ? _closeCondition : _farCondition;
            Gizmos.DrawWireSphere(_partner.transform.position, _distanceThreshold);
        }
#endif
    }
}