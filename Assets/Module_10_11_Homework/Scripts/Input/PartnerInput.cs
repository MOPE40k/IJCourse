using UnityEngine;
using Module_10_11_Homework.Controllers;
using Module_10_11_Homework.Utils;

namespace Module_10_11_Homework.Inputs
{
    public class PartnerInput : IInput
    {
        private readonly Transform _characterTransform = null;
        private readonly CheckpointsController _checkpointManager = null;
        private const float DistanceThreshold = 1.0f;
        private readonly DistanceChecker _distanceChecker = null;
        public Vector3 MoveAxes => GetMoveDirection();

        public PartnerInput(Transform characterTransform, CheckpointsController checkpointManager)
        {
            _characterTransform = characterTransform;

            _checkpointManager = checkpointManager;
            _checkpointManager.NextRandomCheckpointPosition();

            _distanceChecker = new DistanceChecker(DistanceThreshold);
        }

        private Vector3 GetMoveDirection()
        {
            if (IsCloseTo())
                _checkpointManager.NextRandomCheckpointPosition();

            return CalculateMoveDirection();
        }

        private Vector3 CalculateMoveDirection()
        {
            return _checkpointManager.CurrentCheckpointPosition - _characterTransform.position;
        }

        private bool IsCloseTo()
            => _distanceChecker.CheckDistance(
                _characterTransform.position,
                _checkpointManager.CurrentCheckpointPosition
            );
    }
}