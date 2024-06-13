using UnityEngine;

public interface IUnitFactory
{
    Transform spawnPoint { get; }
    void SpawnUnit(GameObject unitPrefab);
}