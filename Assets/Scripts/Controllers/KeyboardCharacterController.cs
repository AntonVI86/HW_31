using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCharacterController : Controller
{
    private AgentCharacter _character;

    public KeyboardCharacterController(AgentCharacter character)
    {
        _character = character;
    }

    public override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _character.SetDestination(inputDirection);
        
    }
}
