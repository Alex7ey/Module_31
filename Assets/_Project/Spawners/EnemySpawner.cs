using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPosition;

    private int _enemyCount;

    private Coroutine _coroutine;
    private EnemyFactory _enemyFactory = new();

    private EnemyConfig _enemyConfig;
    private LevelConfig _levelConfig;
    private UpdateService _updateService;

    public event Action<Enemy> Spawned;

    public void Initialize(LevelConfig levelConfig, UpdateService controllerUpdateService)
    {
        _enemyConfig = Resources.Load<EnemyConfig>("Configs/EnemyConfig");

        _levelConfig = levelConfig;
        _enemyCount = levelConfig.TotalEnemies;
        _updateService = controllerUpdateService;
    }

    public IEnumerator ProcessSpawn()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            yield return new WaitForSeconds(_levelConfig.EnemySpawnRate);
            Enemy enemy = _enemyFactory.Create(_spawnPosition[Random.Range(0, _spawnPosition.Length)].position, _enemyConfig, _updateService);

            Spawned?.Invoke(enemy);         
        }
    }

    public void Spawn()
    {
        _coroutine = StartCoroutine(ProcessSpawn());
    }

    public void Stop()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    } 
}


