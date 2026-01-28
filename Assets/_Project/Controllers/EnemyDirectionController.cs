using UnityEngine;

public class EnemyDirectionController
{
    private float _directionChangeInterval;
    private float _time;

    private IMovable _mover;
    private Vector3 _currentDirection;

    public EnemyDirectionController(IMovable mover, float directionChangeInterval)
    {
        _mover = mover;
        _directionChangeInterval = directionChangeInterval;
    }

    public void Update(float deltaTime)
    {
        _time += deltaTime;

        if (_time >= _directionChangeInterval)
        {
            _currentDirection = ChangeDirection();
            _time = 0;
        }

        _mover.Move(_currentDirection);
    }

    private Vector3 ChangeDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle;
        return new Vector3(randomDirection.x, 0, randomDirection.y);
    }
}
