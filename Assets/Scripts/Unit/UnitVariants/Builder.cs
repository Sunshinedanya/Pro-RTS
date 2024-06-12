using UnityEngine;

[System.Serializable]
public sealed class Builder : Unit, IBuilder
{
    [SerializeField] private float _gatheringSpeed;
    [SerializeField] private float _repairSpeed;
    [SerializeField] private float _repairEfficiency;

    public float gatheringSpeed => _gatheringSpeed;
    public float repairSpeed => _repairSpeed;
    public float repaitEfficiency => _repairEfficiency;
}