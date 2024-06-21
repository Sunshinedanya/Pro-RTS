using UnityEngine;
using UnityEngine.Events;
using System;

public class CommandsManager : MonoBehaviour
{
    private object _class;

    [SerializeField] private UnityEvent _onCommandChanged;

    public void ClearCommands()
    {
        var component = _class as MonoBehaviour;

        Destroy(component);
    }

    public void StartFollow ()
    {
        _class = gameObject.AddComponent<Follow>();
    }
}
