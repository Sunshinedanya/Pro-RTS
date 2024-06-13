using UnityEngine;

public sealed class Inventory : MonoBehaviour
{
    [SerializeField] private uint _units;
    [SerializeField] private uint _food;
    [SerializeField] private uint _tree;
    [SerializeField] private uint _iron;
    [SerializeField] private uint _stone;

    public bool TrySpend(Cost cost)
    {
        if(_food < cost.food)
            return false;
        if(_tree < cost.tree)
            return false;
        if (_iron < cost.iron)
            return false;
        if (_stone < cost.stone)
            return false;

        Spend(cost);
        return true;
    }

    public void AddUnit(uint amount)
    {
        _units+= amount;
    }

    public void RemoveUnit(uint amount)
    {
        _units-= amount;
    }

    private void Spend(Cost cost)
    {
        _food -= cost.food;
        _tree -= cost.tree;
        _iron -= cost.iron;
        _stone -= cost.stone;
    }
}
