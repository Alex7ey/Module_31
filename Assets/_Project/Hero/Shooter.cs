using UnityEngine;

public class Shooter
{
    private Transform _transform;
    private Projectile _projectilePrefab;

    public Shooter(Transform transform)
    {
        _transform = transform;
        _projectilePrefab = Resources.Load<Projectile>("Prefabs/Bullet");
    }

    public void Shoot()
    {
        Projectile shoot = Object.Instantiate(_projectilePrefab, _transform.position, Quaternion.identity);
        shoot.Move(_transform.forward, 2f);     
    }
}
