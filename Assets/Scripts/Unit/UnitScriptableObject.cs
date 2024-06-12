using UnityEngine;

public abstract class UnitScriptableObject<TUnit> : ScriptableObject
    where TUnit : Unit
{
    [SerializeField] public TUnit unit;

    public virtual TUnit GetUnit()
    {
        return unit;
    }
}