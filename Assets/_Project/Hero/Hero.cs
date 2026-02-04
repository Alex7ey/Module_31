using UnityEngine;

public class Hero : MonoBehaviour, IMovable, IShooter, IDestroyed, IDamagable
{
    [SerializeField] private Transform _shootPosition;

    private Rotator _rotator;
    private Shooter _shooting;
    private HeroMover _mover;

    private int _health = 1;

    public bool IsDestroyed { get; private set; }

    public void Initialize(HeroMover mover, Rotator rotator)
    {
        _mover = mover;
        _rotator = rotator;
        _shooting = new(_shootPosition);
    }

    public void Move(Vector3 direction)
    {
        _mover.Move(direction, Time.deltaTime);
        _rotator.RotateTo(direction, Time.deltaTime);
    }

    public void Shoot()
    {
        _shooting.Shoot();
    }

    public void Destroy()
    {
        IsDestroyed = true;
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy();
        }
    }
}
