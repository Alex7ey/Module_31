using UnityEngine;

public class DirectionController : IUpdatable
{
    private IMovable _mover;

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public DirectionController(IMovable mover)
    {
        _mover = mover;
    }

    public void Update(float deltaTime)
    {
        Vector3 currentDirection = new(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis));

        if (currentDirection != Vector3.zero)
            _mover.Move(currentDirection);
    }
}
