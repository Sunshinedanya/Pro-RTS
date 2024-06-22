using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ClickableSelection : MonoBehaviour
{
    [SerializeField] private List<GameObject> _clickables = new List<GameObject>();
    [SerializeField] private List<GameObject> _clickableSelected = new List<GameObject>();
    [SerializeField] private UnityEvent<GameObject> _onSelected;

    public IReadOnlyList<GameObject> Clickables => _clickables;
    public IReadOnlyList<GameObject> ClickableSelected => _clickableSelected;
    private static ClickableSelection _instance;
    public static ClickableSelection Instance => _instance;


    public void AddUnit(GameObject unit)
    {
        _clickables.Add(unit);
    }

    public void RemoveUnit(GameObject unit)
    {
        _clickables.Remove(unit);
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
        _clickableSelected.Add(unitToAdd);
        _onSelected.Invoke(unitToAdd);
    }

    public void DragSelect(GameObject unitToAdd)
    {
        if (ClickableSelected.Contains(unitToAdd) == false)
        {
            _clickableSelected.Add(unitToAdd);
        }
    }

    public void Deselect()
    {
        _clickableSelected.Clear();
        _onSelected.Invoke(null);
    }
}
