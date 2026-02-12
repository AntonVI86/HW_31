using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRun");
    private readonly int HitKey = Animator.StringToHash("Hit");
    private readonly int DieKey = Animator.StringToHash("Die");

    private float _minValueToMoveAnimation = 0.05f;

    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;
    [SerializeField] private AudioClip _hitSfx;

    private void OnEnable()
    {
        _character.Hited += OnHited;
        _character.Died += OnDied;
        _character.Healed += OnHealed;
    }

    private void Update()
    {
        if (_character.CurrentDirection.magnitude >= _minValueToMoveAnimation)
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

    private void OnHited()
    {
        _animator.SetTrigger(HitKey);
        AudioPlayer.Instance.PlaySound(_hitSfx);
    }

    private void OnDied()
    {
        _animator.SetTrigger(DieKey);
    }

    private void OnHealed()
    {
        //_character.Vfx.Play();
    }

    private void OnDisable()
    {
        _character.Hited -= OnHited;
        _character.Died -= OnDied;
        _character.Healed -= OnHealed;
    }
}
