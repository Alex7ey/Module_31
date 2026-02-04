using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private int _damage = 1;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(_damage);
            Destroy(gameObject);
        }    
    }

    public void Move(Vector3 direction, float movementSpeed)
    {
        _rigidbody.AddForce(direction.normalized * movementSpeed, ForceMode.Impulse);
    }
}
