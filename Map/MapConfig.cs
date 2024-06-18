using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig")]
public class MapConfig : ScriptableObject
{
    public int enemyCount;
    public List<Enemy> enemies = new List<Enemy>();
    public Player player;
    public string difficulty;
    public float mapSize;
}

public struct Enemy
{
    public string name;
    public Color color;
}
public struct Player
{
    public string name;
    public Color color;
}