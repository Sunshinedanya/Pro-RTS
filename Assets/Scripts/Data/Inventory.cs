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
    public void AddResource(ResourceType type)
    {
        switch ((uint)type)
        {
            case 1:
                _food += 1;
                break;
            case 2:
                _tree += 1;
                break;
            case 3:
                _iron += 1;
                break;
            case 4:
                _stone += 1;
                break;
        }
    }
    public void AddResource(ResourceType type, uint amount)
    {
        switch ((uint)type)
        {
            case 1:
                _food += amount;
                break;
            case 2:
                _tree += amount;
                break;
            case 3:
                _iron += amount;
                break;
            case 4:
                _stone += amount;
                break;
        }
    }
}

public enum ResourceType : uint
{
    food = 1,
    tree = 2,
    iron = 3,
    stone = 4
}