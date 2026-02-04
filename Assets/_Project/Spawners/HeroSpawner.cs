using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    private HeroConfig _config;
    private HeroFactory _heroFactory = new();

    private UpdateService _updateService;

    public void Initialize(UpdateService updateService)
    {
        _config = Resources.Load<HeroConfig>("Configs/HeroConfig");
        _updateService = updateService;
    }

    public Hero Spawn()
    {
        Hero character = _heroFactory.Create(_config);

        DirectionController characterInputController = new(character);
        _updateService.Add(characterInputController, () => character.IsDestroyed);

        ShootController inputShootController = new(character);
        _updateService.Add(inputShootController, () => character.IsDestroyed);

        return character;
    }


}
