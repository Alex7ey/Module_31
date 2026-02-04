using System;
using System.Collections.Generic;

public class EnemyRegistryService : IDisposable, IUpdatable
{
    private EnemySpawner _enemySpawner;

    private List<Enemy> _enemys = new();

    public EnemyRegistryService(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
        _enemySpawner.Spawned += Add;
    }

    public IReadOnlyList<Enemy> Enemys => _enemys;

    public int AliveEnemiesCount => _enemys.Count;
    public int EnemiesKilled { get; private set; }

    public void Add(Enemy enemy)
    {
        _enemys.Add(enemy);
    }

    public void Update(float deltaTime)
    {
        int destroyedEnemy = _enemys.RemoveAll(enemy => enemy.IsDestroyed);
        EnemiesKilled += destroyedEnemy;
    }

    public void Dispose()
    {
        _enemySpawner.Spawned -= Add;
    }
}
