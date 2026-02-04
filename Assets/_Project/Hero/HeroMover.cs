using UnityEngine;

public class HeroMover
{
    private Rigidbody _rigidbody;
    private float _speed;

    public HeroMover(Rigidbody rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;     
    }

    public void Move(Vector3 direction, float deltaTime)
    {    
        _rigidbody.AddForce(_speed * deltaTime * direction.normalized);  
    } 
}
