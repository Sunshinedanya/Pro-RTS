using System;
using UnityEngine;

public class UnitInstacer : MonoBehaviour
{
    public static void Instantiate<TUnit>(UnitScriptableObject<TUnit> unit, GameObject unitPrefab, Transform spawnPoint)
        where TUnit : Unit
    {
        var isUnit = unitPrefab.TryGetComponent(out UnitComponent<TUnit> unitComponent);

        if (isUnit)
        {
            unitComponent.FillUnit(unit);
            Instantiate(unitComponent, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            throw new ArgumentException("Unit do not have req component");
        }
    }
}