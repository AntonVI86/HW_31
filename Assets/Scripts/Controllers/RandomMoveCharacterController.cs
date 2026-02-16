using UnityEngine;
using UnityEngine.AI;

public class RandomMoveCharacterController : Controller
{
    private IMovable _movable;

    private Vector3 _defaultPosition;
    private Vector3 _targetPoint;

    private float _minDistanceToTarget = 0.2f;
    private float _minDistanceToDefaultPoint = -5f;
    private float _maxDistanceToDefaultPoint = 5f;

    private NavMeshPath _pathToTarget = new NavMeshPath();

    public RandomMoveCharacterController(AgentCharacter character, Vector3 defaultPosition)
    {
        _movable = character;
        _defaultPosition = defaultPosition;

        SetTargetPoint();
    }

    public override void UpdateLogic(float deltaTime)
    {
        if (_movable.IsAlive == false)
            return;

        _movable.SetRotationDirection(_movable.CurrentDirection);

        if (_movable.TryGetPath(_targetPoint, _pathToTarget) == false)
        {
            SetTargetPoint();
        }

        float distanceToTarget = NavMeshUtils.GetPathLength(_pathToTarget);

        if (IsTargetReached(distanceToTarget))
        {
            _movable.StopMove();
            SetTargetPoint();
        }

        if (EnoughCornersToPath(_pathToTarget))
        {
            _movable.ResumeMove();
            _movable.SetMoveDirection(_targetPoint);
            return;
        }

        _movable.StopMove();
    }

    private void SetTargetPoint()
    {
        _targetPoint = new Vector3(_defaultPosition.x + Random.Range(_minDistanceToDefaultPoint, _maxDistanceToDefaultPoint),
            _defaultPosition.y, _defaultPosition.z + Random.Range(_minDistanceToDefaultPoint, _maxDistanceToDefaultPoint));
    }

    private bool IsTargetReached(float distanceToTarget) => distanceToTarget <= _minDistanceToTarget;
    private bool EnoughCornersToPath(NavMeshPath pathToTarget) => _pathToTarget.corners.Length > 1;
}
