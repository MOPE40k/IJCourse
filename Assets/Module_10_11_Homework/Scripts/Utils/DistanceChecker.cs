using UnityEngine;

namespace Module_10_11_Homework.Utils
{
    public class DistanceChecker
    {
        private readonly float _distanceThreshold = 0f;
        public DistanceChecker(float distanceThreshold)
        {
            _distanceThreshold = distanceThreshold;
        }

        public bool CheckDistance(Vector3 pointA, Vector3 pointB)
        {
            float distance = (pointA - pointB).sqrMagnitude;
            return distance <= _distanceThreshold * _distanceThreshold;
        }
    }
}