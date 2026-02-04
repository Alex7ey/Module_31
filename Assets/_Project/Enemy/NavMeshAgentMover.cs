using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentMover 
{
    private NavMeshAgent _navMeshAgent;
    private Transform _transform;

    public NavMeshAgentMover(NavMeshAgent navMeshAgent, Transform transform, float movementSpeed)
    {
        _navMeshAgent = navMeshAgent;
        _navMeshAgent.speed = movementSpeed;
        _transform = transform;
    }

    public void Move(Vector3 direction)
    {
        _navMeshAgent.SetDestination(_transform.position + direction.normalized);
    }
}
