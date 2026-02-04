using System;
using UnityEngine;

public class GameRulesFactory
{
    private float _startTime;

    private Hero _hero;
    private LevelConfig _levelConfig;
    private EnemyRegistryService _enemyRegistryService;

    public GameRulesFactory(Hero hero, LevelConfig levelConfig, EnemyRegistryService enemyRegistryService)
    {
        _hero = hero;
        _levelConfig = levelConfig;
        _enemyRegistryService = enemyRegistryService;

        _startTime = Time.time;
    }

    public GameRules CreateGameRules() => new GameRules(GetRule(_levelConfig.WinCondition), GetRule(_levelConfig.LoseCondition));
   
    private Func<bool> GetRule(TypeGameRules rule)
    {
        switch (rule)
        {
            case TypeGameRules.Time:
                return HasTimeElapsed;

            case TypeGameRules.KillCount:
                return HasRequiredKillCount;

            case TypeGameRules.IsDead:
                return IsPlayerDead;

            case TypeGameRules.EnemyLimited:
                return IsEnemyLimitExceeded;

            default:
                new ArgumentException($"Данный тип {rule} данных не предусмотрен");
                return null;
        }
    }

    private bool HasTimeElapsed() => Time.time - _startTime >= _levelConfig.TimeToSurvive;

    private bool HasRequiredKillCount() => _enemyRegistryService.EnemiesKilled >= _levelConfig.KillQuota;

    private bool IsPlayerDead() => _hero.IsDestroyed;

    private bool IsEnemyLimitExceeded() => _enemyRegistryService.AliveEnemiesCount >= _levelConfig.MaxAliveEnemies;
}
