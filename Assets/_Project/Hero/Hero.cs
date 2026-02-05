using UnityEngine;

public class Hero : MonoBehaviour, IMovable, IShooter, IDestroyed, IDamagable
{
    [SerializeField] private Transform _shootPosition;

    private Rotator _rotator;
    private Shooter _shooting;
    private HeroMover _mover;
    private Health _health;

    public bool IsDestroyed { get; private set; }

    public void Initialize(HeroMover mover, Rotator rotator, Health health)
    {
        _mover = mover;
        _rotator = rotator;
        _health = health;

        _shooting = new(_shootPosition);
        _health.Died += Destroy;
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
        _health.Died -= Destroy;

        Destroy(gameObject);
    }

    public void TakeDamage(int damage) => _health.TakeDamage(damage);
}
