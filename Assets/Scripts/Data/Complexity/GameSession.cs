using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSession
{
    public float enemyCooldown;
    public List<GameObject> enemyPrefabs;
    public int armySize;
    public int armyMultiplier;

    public float mapSize;

    public int enemyAmount;
}

