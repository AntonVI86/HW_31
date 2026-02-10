using UnityEngine;

public class PlayerDirectionRotateableController : Controller
{
    private IDirectionalRotatable _rotatable;

    public override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _rotatable.SetRotationDirection(inputDirection);
    }
}
