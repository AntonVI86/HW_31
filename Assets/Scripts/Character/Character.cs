using UnityEngine;

public class Character : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable
{
    [SerializeField] private Transform _cameraTarget;

    private CharacterController _characterController;

    private DirectionalMover _mover;
    private DirectionalRotator _rotator;

    public Transform CameraTarget => _cameraTarget;

    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public Vector3 CurrentDirection => _mover.CurrentVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        _mover = new DirectionalMover(_characterController, 5);
        _rotator = new DirectionalRotator(transform, 800f);
    }

    private void Update()
    {
        _mover.Update(Time.deltaTime);
        _rotator.Update(Time.deltaTime);
    }
    public void SetMoveDirection(Vector3 direction) => _mover.SetInputDirection(direction);

    public void SetRotationDirection(Vector3 direction) => _rotator.SetInputDirection(direction);
}
