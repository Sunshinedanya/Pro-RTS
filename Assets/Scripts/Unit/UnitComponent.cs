using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class UnitComponent<TUnit> : MonoBehaviour, ISerializationCallbackReceiver
    where TUnit : Unit
{
    [SerializeField] private UnitScriptableObject<TUnit> _unitStats;
    [SerializeField] private TUnit _unit;

    public void OnAfterDeserialize()
    {
        _unit = _unitStats.GetUnit();
    }

    public void OnBeforeSerialize()
    {
    }
}
