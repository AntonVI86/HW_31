using UnityEngine;

public class PlayerDirectionMoveableController : Controller
{
    private IDirectionalMovable _movable;

    public PlayerDirectionMoveableController(IDirectionalMovable movable)
    {
        _movable = movable;
    }

    public override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _movable.SetMoveDirection(inputDirection);
    }
}
