
using UnityEngine;
using UnityEngine.AI;

public class EnemyFactory
{
    public Enemy Create(Vector3 spawnPosition, EnemyConfig config, UpdateService updateService)
    {
        Enemy enemy = Object.Instantiate(config.Prefab, spawnPosition, Quaternion.identity);

        NavMeshAgentMover mover = new(enemy.GetComponent<NavMeshAgent>(), enemy.transform, config.MovementSpeed);

        AgentDirectionController agentDirectionController = new(enemy, config.DirectionChangeIntervalEnemy);
        updateService.Add(agentDirectionController, () => enemy.IsDestroyed);

        enemy.Initialize(mover, new Health(config.Health));

        return enemy;
    }
}
