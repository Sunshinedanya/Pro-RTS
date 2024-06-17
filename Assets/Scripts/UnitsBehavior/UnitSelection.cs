using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    [SerializeField] private List<GameObject> _units = new List<GameObject>();
    [SerializeField] private List<GameObject> _unitSelected = new List<GameObject>();

    public IReadOnlyList<GameObject> units => _units;

    private static UnitSelection _instance;
    public static UnitSelection Instance => _instance;

    public void AddUnit(GameObject unit)
    {
        _units.Add(unit);
    }

    public void RemoveUnit(GameObject unit)
    {
        _units.Remove(unit);
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        Deselect();
        _unitSelected.Add(unitToAdd);
    }

    public void DragSelect(GameObject unitToAdd)
    {

    }

    public void Deselect()
    {
        _unitSelected.Clear();
    }
}
