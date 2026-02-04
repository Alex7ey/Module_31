using System;
using UnityEngine;

public class GameMode : IUpdatable
{
    public event Action Win;
    public event Action Defeat;

    private Func<bool> _winCondition;
    private Func<bool> _loseCondition;

    private EnemySpawner _enemySpawner;
    private EnemyRegistryService _enemyRegistryService;

    public GameMode(GameRules rules, EnemyRegistryService enemyRegistryService, EnemySpawner enemySpawner)
    {
        _winCondition = rules.WinCondition;
        _loseCondition = rules.LoseCondition;
        _enemyRegistryService = enemyRegistryService;
        _enemySpawner = enemySpawner;
    }

    public bool IsRunning { get; private set; } = true;

    public void Update(float deltaTime)
    {
        if (IsRunning == false)
            return;

        if (_winCondition.Invoke())
            WinGame();

        if (_loseCondition.Invoke())
            LoseGame();
    }

    private void WinGame()
    {
        Win?.Invoke();
        IsRunning = false;

        _enemySpawner.Stop();
        RemoveEnemies();

        Debug.Log("Win");
    }

    private void LoseGame()
    {
        Defeat?.Invoke();
        IsRunning = false;

        Debug.Log("Defeat");
    }

    private void RemoveEnemies()
    {
        foreach (var enemy in _enemyRegistryService.Enemys)
            enemy.Destroy();
    }
}
