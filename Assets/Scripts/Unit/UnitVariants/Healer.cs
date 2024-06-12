using UnityEngine;

[System.Serializable]
public sealed class Healer : Unit, IHealer
{
    [SerializeField] private float _heal;
    [SerializeField] private float _minHealRange;
    [SerializeField] private float _maxHealRange;
    [SerializeField] private float _healCooldown;

    public float heal => _heal;
    public float minHealRange => _minHealRange;
    public float maxHealRange => _maxHealRange;
    public float healCooldown => _healCooldown;
}