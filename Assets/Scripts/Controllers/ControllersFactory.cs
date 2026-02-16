using UnityEngine;

public class ControllersFactory
{
    public RandomMoveCharacterController CreateRandomMoveCharacterController()
    {
        return new RandomMoveCharacterController();
    }
}
