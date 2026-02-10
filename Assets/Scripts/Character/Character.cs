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
        _rotator = new DirectionalRotator(transform, 100f);
    }

    private void Update()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        SetMoveDirection(inputDirection);
        SetRotationDirection(inputDirection);

        _mover.Update(Time.deltaTime);
        _rotator.Update(Time.deltaTime);
    }
    public void SetMoveDirection(Vector3 direction) => _mover.SetInputDirection(direction);

    public void SetRotationDirection(Vector3 direction) => _rotator.SetInputDirection(direction);
}
