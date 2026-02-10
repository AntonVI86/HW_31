using UnityEngine;

public class PlayerDirectionRotatableController : Controller
{
    private IDirectionalRotatable _rotatable;

    public PlayerDirectionRotatableController(IDirectionalRotatable rotatable)
    {
        _rotatable = rotatable;
    }

    public override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _rotatable.SetRotationDirection(inputDirection);
    }
}
