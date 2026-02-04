using UnityEngine;

public class Enemy : MonoBehaviour, IMovable, IDamagable, IDestroyed
{
    private NavMeshAgentMover _mover;
    private int _health;

    public bool IsDestroyed { get; private set; }

    public void Initialize(NavMeshAgentMover mover, int health)
    {
        _mover = mover;
        _health = health;
    }

    public void Move(Vector3 direction)
    {
        if(IsDestroyed)
            return;

        _mover.Move(direction);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy();
        }       
    }

    public void Destroy()
    {
        IsDestroyed = true;
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
