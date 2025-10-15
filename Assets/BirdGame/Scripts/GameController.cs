using UnityEngine;

namespace BirdGame
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _playerCharacter = null;
        [SerializeField] private KeyCode _restartKey = KeyCode.R;
        [SerializeField] private int _jumpCountToWin = 10;
        [SerializeField] private ScoreCounter _scoreCounter = null;
        [SerializeField] private BordersController _bordersController = null;
        [SerializeField] private Animator _cameraAnimator = null;
        private const string _cameraShakeKey = "Shake";

        private bool _isRunning = false;

        private void Start()
        {
            _bordersController.Init();

            StartGame();
        }

        private void Update()
        {
            if (_isRunning == false)
            {
                if (Input.GetKeyDown(_restartKey))
                {
                    StartGame();
                }

                return;
            }

            if (IsWinConditionSuccesful())
            {
                Debug.Log("Поздравляем!");

                GameOver();
            }

            if (IsBoarderOverlap())
                GameOver();
        }



        private void StartGame()
        {
            _isRunning = true;

            _playerCharacter.Init(Vector3.zero);

            _scoreCounter.Reset();
        }

        private void GameOver()
        {
            _isRunning = false;

            _playerCharacter.GameOver();

            _cameraAnimator.SetTrigger(_cameraShakeKey);

            Debug.Log($"Ваш счёт: {_scoreCounter.Score}");
        }

        private bool IsWinConditionSuccesful()
            => _scoreCounter.Score >= _jumpCountToWin;

        private bool IsBoarderOverlap()
            => _bordersController.IsBoardersOverlap(_playerCharacter.transform.position);
    }
}