using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private HeroSpawner _mainHeroSpawner;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private UpdateService _updateService;

    private GameMode _gameMode;
    private EnemyRegistryService _enemyRegistryService;

    private void Awake()
    {
        _enemySpawner.Initialize(_levelConfig, _updateService);
        _mainHeroSpawner.Initialize(_updateService);

        _enemyRegistryService = new(_enemySpawner);
        _updateService.Add(_enemyRegistryService, () => _gameMode.IsRunning == false);

        GameStart();
    }

    private void GameStart()
    {
        _enemySpawner.Spawn();
        Hero hero = _mainHeroSpawner.Spawn();

        GameRulesFactory gameRulesFactory = new(hero, _levelConfig, _enemyRegistryService);
        GameRules gameRules = gameRulesFactory.CreateGameRules();

        _gameMode = new(gameRules, _enemyRegistryService, _enemySpawner);
        _updateService.Add(_gameMode, () => _gameMode.IsRunning == false);
    }
}
