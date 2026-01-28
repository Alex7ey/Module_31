using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IMovable
{
    private Mover _mover;

    private void Awake()
    {
        _mover = new(GetComponent<NavMeshAgent>(), transform);
    }

    public void Move(Vector3 direction)
    {
       _mover.Move(direction);
    }
}
