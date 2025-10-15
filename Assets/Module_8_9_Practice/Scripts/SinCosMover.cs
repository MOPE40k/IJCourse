using UnityEngine;

namespace ZigZag.Common
{
    public class SinCosMover : MonoBehaviour
    {                                                                   // 1.0
        [SerializeField] private Transform _sceneCentre = null;
        [SerializeField] private float _movingSpeed = 2f;               // 1.1
        [SerializeField] private float _maxAmplitude = 1f;              // 1.2
        [SerializeField] private MovingType _movingType = MovingType.X; // 1.3
        private Vector3 _startingPosition;                              // 1.4

        private void Awake()                                            // 2.0
        {
            _startingPosition = transform.position;                     // 2.1
        }

        void Update()                                                   // 3.0
        {
            var time = Time.time * _movingSpeed;                        // 3.1

            float xOffset = Mathf.Sin(time) * _maxAmplitude;            // 3.2
            float yOffset = Mathf.Cos(time) * _maxAmplitude;            // 3.3

            transform.position = _startingPosition + _movingType switch // 3.4
            {
                MovingType.X => new Vector3(xOffset, 0, 0),
                MovingType.Y => new Vector3(0, xOffset, 0),
                MovingType.Z => new Vector3(0, 0, xOffset),
                MovingType.XY => new Vector3(xOffset, yOffset, 0),
                MovingType.YX => new Vector3(yOffset, xOffset, 0),
                MovingType.X_Y => new Vector3(xOffset, 0, yOffset),
                MovingType.Y_X => new Vector3(yOffset, 0, xOffset),
                _ => Vector3.zero
            };

            transform.LookAt(_sceneCentre);
        }

        private enum MovingType                                         // 4.0
        {
            X = 0,
            Y,
            Z,
            XY,
            YX,
            X_Y,
            Y_X
        }
    }
}