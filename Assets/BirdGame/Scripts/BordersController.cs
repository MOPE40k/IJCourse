using UnityEngine;

namespace BirdGame
{
    public class BordersController : MonoBehaviour
    {
        [SerializeField] private Transform _upperBoundry = null;
        [SerializeField] private Transform _bottomBoundry = null;
        [SerializeField] private Transform _leftBoundry = null;
        [SerializeField] private Transform _rightBoundry = null;

        [SerializeField] private float _horizontalBoundryPosition = 8.0f;
        [SerializeField] private float _verticalBoundryPosition = 4.0f;

        [SerializeField] private float _YLimit = 4.5f;
        [SerializeField] private float _XLimit = 4;

        public void Init()
        {
            _upperBoundry.position = new Vector3(0f, _horizontalBoundryPosition, 0f);
            _bottomBoundry.position = new Vector3(0f, -_horizontalBoundryPosition, 0f);
            _leftBoundry.position = new Vector3(-_verticalBoundryPosition, 0f, 0f);
            _rightBoundry.position = new Vector3(_verticalBoundryPosition, 0f, 0f);
        }

        public bool IsBoardersOverlap(Vector3 targetPosition)
        {
            return targetPosition.x < -_XLimit
                || targetPosition.x > _XLimit
                || targetPosition.y > _YLimit
                || targetPosition.y < -_YLimit;
        }
    }
}