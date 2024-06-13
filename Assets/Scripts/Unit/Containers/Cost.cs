using UnityEngine;

[System.Serializable]
public class Cost : ICost
{
    [SerializeField] private uint _food;
    [SerializeField] private uint _tree;
    [SerializeField] private uint _iron;
    [SerializeField] private uint _stone;

    public uint food => _food;
    public uint tree => _tree;
    public uint iron => _iron;
    public uint stone =>_stone;

    public Cost GetCost()
    {
        return this;
    }
}
