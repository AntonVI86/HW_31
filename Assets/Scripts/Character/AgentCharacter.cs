using System;
using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour, IDamageable, IMovable, IDirectionalRotatable
{
    public event Action Hited;
    public event Action Healed;
    public event Action Died;

    private AgentMover _mover;
    private DirectionalRotator _rotator;

    private float _currentHealth;

    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _maxHealth;
    [SerializeField] private ParticleSystem _vfx;
    public Vector3 CurrentDirection => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;
    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    public bool IsAlive => _currentHealth > 0;

    public ParticleSystem Vfx => _vfx;

    public Vector3 Position => throw new NotImplementedException();

    public void Initialize()
    {
        _mover = new AgentMover(_agent, 5);
        _currentHealth = _maxHealth;

        _rotator = new DirectionalRotator(transform, _rotationSpeed);

        foreach (IInitializable initializable in GetComponentsInChildren<IInitializable>())
            initializable.Initialize();
    }

    private void Update()
    {
        _rotator.Update(Time.deltaTime);
    }

    public void SetDestination(Vector3 position) => _mover.SetDestination(position);
    public void StopMove() => _mover.Stop();
    public void ResumeMove() => _mover.Resume();
    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);
    public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget)
        => NavMeshUtils.TryGetPath(_agent, targetPosition, pathToTarget);

    public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData)
    {
        if (_agent.isOnOffMeshLink)
        {
            offMeshLinkData = _agent.currentOffMeshLinkData;
            return true;
        }

        offMeshLinkData = default(OffMeshLinkData);
        return false;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _currentHealth -= damage;
        SetMoveDirection(transform.position);
        Hited?.Invoke();

        if(_currentHealth < 0)
        {
            _currentHealth = 0;
            SetMoveDirection(transform.position);
            
            Died?.Invoke();
        }
    }

    public void Heal(float value)
    {
        if (value < 0)
            return;

        _currentHealth += value;
        Healed?.Invoke();

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }

    public void SetMoveDirection(Vector3 direction)
    {
        _mover.SetDestination(direction);
    }
}
