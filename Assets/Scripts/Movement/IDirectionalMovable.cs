using UnityEngine;

public interface IDirectionalMovable
{
    Vector3 CurrentDirection { get; }
    void SetMoveDirection(Vector3 direction);
}
