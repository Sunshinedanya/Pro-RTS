using UnityEngine;

public abstract class BuildingCompopnent<TBuilding> : MonoBehaviour
    where TBuilding : class, IBuilding
{
    [SerializeField] private TBuilding _building;
    [SerializeField] protected Inventory _inventory;

    private void Start()
    {
        _inventory = _inventory.GetComponent<Inventory>();
        ClickableSelection.Instance.AddUnit(this.gameObject);
    }
}
