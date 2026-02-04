using UnityEngine;

public class Rotator
{
    private Transform _transform;
    private float _rotationSpeed;

    public Rotator(Transform transform, float rotationSpeed)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    public void RotateTo(Vector3 direction, float deltaTime)
    {
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            float step = _rotationSpeed * deltaTime;
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
        }
    }
}
