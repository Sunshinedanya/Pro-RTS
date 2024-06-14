using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class UnitComponent : MonoBehaviour
{
    public abstract Unit GetUnit();
}

[RequireComponent(typeof(NavMeshAgent))]
public abstract class UnitComponent<TUnit> : UnitComponent
    where TUnit : Unit
{
    [SerializeField] private TUnit _unit;
    [SerializeField] private UnityEvent _onSelected;

    public override Unit GetUnit()
    {
        return _unit;
    }

    public Type GetType() 
    { 
        return _unit.GetType(); 
    }  

    public void FillUnit(UnitScriptableObject<TUnit> unitScriptableObject)
    {
        _unit = unitScriptableObject.unit;
    }
}
