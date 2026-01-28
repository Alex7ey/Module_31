using UnityEngine;
using UnityEngine.AI;

public class Mover
{
    private NavMeshAgent _navMeshAgent;
    private Transform _transform;

    public Mover(NavMeshAgent navMeshAgent, Transform transform)
    {
        _navMeshAgent = navMeshAgent;
        _transform = transform;
    }

    public void Move(Vector3 direction)
    {
        _navMeshAgent.SetDestination(_transform.position + direction.normalized);
    }
}
