using UnityEngine;

public class KeyboardPlayerController : Controller
{
    private Character _character;

    public KeyboardPlayerController(Character character)
    {
        _character = character;
    }

    public override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _character.SetMoveDirection(inputDirection);
        _character.SetRotationDirection(inputDirection);
    }
}
