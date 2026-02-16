using UnityEngine;

public class MovableView : MonoBehaviour, IInitializable
{
    [SerializeField] private Animator _animator;

    private readonly int IsRunningKey = Animator.StringToHash("IsRun");

    private IMovable _movable;

    private bool _isInit;

    private float _minValueToMoveAnimation = 0.05f;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        _movable = GetComponentInParent<IMovable>();
        _isInit = true;
    }

    private void Update()
    {
        if (_isInit == false)
            return;

        if (_movable.CurrentDirection.magnitude >= _minValueToMoveAnimation)
            StartRunning();
        else
            StopRunning();
    }

    private void StartRunning()
    {
        _animator.SetBool(IsRunningKey, true);
    }

    private void StopRunning()
    {
        _animator.SetBool(IsRunningKey, false);
    }
}
