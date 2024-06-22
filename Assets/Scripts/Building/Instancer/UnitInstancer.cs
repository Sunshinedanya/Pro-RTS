using System;
using UnityEngine;

public sealed class UnitInstacer : MonoBehaviour
{
    public static void Instantiate<TUnit>(UnitScriptableObject<TUnit> unit, GameObject unitPrefab, Transform spawnPoint)
        where TUnit : Unit
    {
        var isUnit = unitPrefab.TryGetComponent(out UnitComponent<TUnit> unitComponent);

        if (isUnit)
        {
            unitComponent.FillUnit(unit);
            var instance = Instantiate(unitComponent, spawnPoint.position, Quaternion.identity);
            ClickableSelection.Instance.AddUnit(instance.gameObject);
        }
        else
        {
            throw new ArgumentException("Unit do not have req component");
        }
    }
}