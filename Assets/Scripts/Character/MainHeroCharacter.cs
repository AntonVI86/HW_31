using System;
using UnityEngine;

public class MainHeroCharacter : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable
{
    [SerializeField] private Transform _cameraTarget;

    public event Action Hited;
    public event Action Healed;
    public event Action Died;

    private CharacterController _characterController;

    private DirectionalMover _mover;
    private DirectionalRotator _rotator;

    public Transform CameraTarget => _cameraTarget;

    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public Vector3 CurrentDirection => _mover.CurrentVelocity;

    public void Initialize()
    {
        _characterController = GetComponent<CharacterController>();

        _mover = new DirectionalMover(_characterController, 5);
        _rotator = new DirectionalRotator(transform, 800f);

        foreach (IInitializable initializable in GetComponentsInChildren<IInitializable>())
            initializable.Initialize();
    }

    private void Update()
    {
        _mover.Update(Time.deltaTime);
        _rotator.Update(Time.deltaTime);
    }

    public void SetMoveDirection(Vector3 direction) => _mover.SetInputDirection(direction);

    public void SetRotationDirection(Vector3 direction) => _rotator.SetInputDirection(direction);
}
