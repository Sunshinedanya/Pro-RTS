using UnityEngine;

[System.Serializable]
public abstract class Building : IBuilding
{
    [SerializeField] private uint _health;
    [SerializeField] private uint _maxHealth;
    [SerializeField] private Cost _cost;

    public uint health => _health;
    public uint maxHealth => _maxHealth;
    public Cost cost => _cost;
}
