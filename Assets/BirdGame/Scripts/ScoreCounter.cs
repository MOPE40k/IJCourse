using System;
using UnityEngine;

namespace BirdGame
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _bird = null;
        [SerializeField] private int _ordinaryScoreValue = 1;
        [SerializeField] private int _bonusScoreValue = 3;
        public int Score { get; private set; } = 0;
        private void Update()
            => Score = CalculateScore();

        public void Reset()
            => Score = 0;

        private int CalculateScore()
        {
            int ordinaryJumpScore = _bird.OrdinaryJumpCount * _ordinaryScoreValue;
            int sideJumpScore = _bird.SideJumpCount * _bonusScoreValue;

            int result = ordinaryJumpScore + sideJumpScore;

            Debug.Log($"Ваш счёт: {result}");

            return result;
        }
    }
}