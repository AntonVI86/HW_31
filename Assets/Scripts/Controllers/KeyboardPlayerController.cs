using UnityEngine;

public class KeyboardPlayerController : Controller
{
    private MainHeroCharacter _character;

    public KeyboardPlayerController(MainHeroCharacter character)
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
