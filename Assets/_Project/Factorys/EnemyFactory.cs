
using UnityEngine;
using UnityEngine.AI;

public class EnemyFactory
{
    public Enemy Create(Vector3 spawnPosition, EnemyConfig config)
    {
        Enemy enemy = Object.Instantiate(config.Prefab, spawnPosition, Quaternion.identity);

        NavMeshAgentMover mover = new(enemy.GetComponent<NavMeshAgent>(), enemy.transform, config.MovementSpeed);
   
        enemy.Initialize(mover, config.Health);

        return enemy;
    }
}
