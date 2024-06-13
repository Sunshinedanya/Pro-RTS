using UnityEngine;

public class UnitFactory : BuildingCompopnent<Building>, IUnitFactory
{
    [SerializeField] private Transform _spawnPoint;

    public Transform spawnPoint => _spawnPoint;

    public void SpawnUnit(GameObject unitPrefab)
    {
        var unitComponent = unitPrefab.GetComponent<UnitComponent>();
        var unit = unitComponent.GetUnit();
        var cost = unit._cost;

        var succsesful = _inventory.TrySpend(cost);

        if (succsesful)
        {
            Instantiate(unitPrefab, _spawnPoint.position, Quaternion.identity);
        }
    }
}

