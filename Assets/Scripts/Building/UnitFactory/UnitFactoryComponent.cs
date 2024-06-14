using UnityEngine;

public abstract class UnitFactoryComponent : BuildingCompopnent<Building>, IUnitFactory
{
    [SerializeField] private Transform _spawnPoint;
    public Transform spawnPoint => _spawnPoint;
    public abstract void SpawnUnit(GameObject unitPrefab);
}

public abstract class UnitFactoryComponent<TUnit> : UnitFactoryComponent
    where TUnit : Unit
{
    [SerializeField] private UnitScriptableObject<TUnit> _unitData;

    public override void SpawnUnit(GameObject unitPrefab)
    {
        var unitComponent = unitPrefab.GetComponent<UnitComponent>();
        var unit = unitComponent.GetUnit();
        var cost = unit._cost;

        var succsesful = _inventory.TrySpend(cost);

        if (succsesful)
        {
            UnitInstacer.Instantiate(_unitData, unitPrefab, spawnPoint);
        }
    }
}