using UnityEngine;

public class HeroFactory
{
    public Hero Create(HeroConfig config)
    {
        Hero character = Object.Instantiate(config.Prefab, config.SpawnPosition, Quaternion.identity);

        HeroMover mover = new (character.GetComponent<Rigidbody>(), config.MovementSpeed);
        Rotator rotator = new(character.transform, config.RotationSpeed);   

        character.Initialize(mover, rotator);

        return character;
    }
}



