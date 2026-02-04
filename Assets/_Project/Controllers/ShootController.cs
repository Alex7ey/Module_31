using UnityEngine;

public class ShootController : IUpdatable
{
    private IShooter _shooter;

    public ShootController(IShooter shooter)
    {
        _shooter = shooter;
    }

    public void Shoot() => _shooter.Shoot();
   
    public void Update(float deltaTime)
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }
}
