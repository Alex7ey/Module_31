using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Enemy", fileName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public Enemy Prefab { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public float DirectionChangeIntervalEnemy { get; private set; }
}
