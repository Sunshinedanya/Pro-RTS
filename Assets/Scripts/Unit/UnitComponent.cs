using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitComponent : MonoBehaviour
{
    public abstract Unit GetUnit();
}

[RequireComponent(typeof(NavMeshAgent))]
public abstract class UnitComponent<TUnit> : UnitComponent
    where TUnit : Unit
{
    [SerializeField] private TUnit _unit;

    public override Unit GetUnit()
    {
        return _unit;
    }

    public Type GetUnitType() 
    { 
        return _unit.GetType(); 
    }  

    public void FillUnit(UnitScriptableObject<TUnit> unitScriptableObject)
    {
        _unit = unitScriptableObject.dataElement;
    }

    public void GetDamage(int damage)
    {
        _unit._health -= damage;
        if(_unit._health <= 0)
        {
            Kill(); 
        }
    }

    private void Kill()
    {
        UnitSelection.Instance.RemoveUnit(gameObject);
        Destroy(gameObject);
    }
}
