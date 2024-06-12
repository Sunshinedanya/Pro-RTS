using System.Collections.Generic;
using UnityEngine;

public abstract class UnitScriptableObject<TUnit> : ScriptableObject
    where TUnit : Unit
{
    [SerializeField] public TUnit unit;

    public virtual Unit GetUnit()
    {
        return unit;
    }
}