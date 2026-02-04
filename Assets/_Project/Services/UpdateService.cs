using System;
using System.Collections.Generic;
using UnityEngine;

public class UpdateService : MonoBehaviour 
{
    private List<ServiceToRemoveReason> _updatables = new();

    private void Update()
    {
        _updatables.RemoveAll(element => element.RemoveReason.Invoke());

        foreach (var element in _updatables)
            element.Updatable.Update(Time.deltaTime);
    }

    public void Add(IUpdatable updatable, Func<bool> removeReason)
    {
        _updatables.Add(new ServiceToRemoveReason(updatable, removeReason));
    }
}

public class ServiceToRemoveReason
{
    public ServiceToRemoveReason(IUpdatable updatable, Func<bool> removeReason)
    {
        RemoveReason = removeReason;
        Updatable = updatable;
    }

    public Func<bool> RemoveReason { get; }
    public IUpdatable Updatable { get; }
}
