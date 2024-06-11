using System.Collections.Generic;
using UnityEngine;

public abstract class UnitScriptableObject : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _detectionRange;
    [SerializeField] private List<object> cost;

    public abstract TUnit GetUnit<TUnit>()
        where TUnit : Unit;
}