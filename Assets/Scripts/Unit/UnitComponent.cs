using UnityEngine;

public class UnitComponent<TUnit> : MonoBehaviour
    where TUnit : Unit
{
    private TUnit _unitStats;

    public UnitComponent(TUnit unitStats)
    {
        _unitStats = unitStats;
    }
}
