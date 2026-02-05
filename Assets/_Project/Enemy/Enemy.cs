using UnityEngine;

public class Enemy : MonoBehaviour, IMovable, IDamagable, IDestroyed
{
    private NavMeshAgentMover _mover;
    private Health _health;

    public bool IsDestroyed { get; private set; }

    public void Initialize(NavMeshAgentMover mover, Health health)
    {
        _mover = mover;
        _health = health;

        _health.Died += Destroy;
    }

    public void Move(Vector3 direction)
    {
        if(IsDestroyed)
            return;

        _mover.Move(direction);
    }

    public void TakeDamage(int damage) => _health.TakeDamage(damage);
   
    public void Destroy()
    {
        IsDestroyed = true;

        _health.Died -= Destroy;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out Hero character))
        {
            character.TakeDamage(1);
        }
    }
}
