using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLayouter : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;

    [SerializeField] private Transform _content;

    [SerializeField] private GameObject _gameConfigPanel;//1
    [SerializeField] private GameObject _contestantPanel;//2
    [SerializeField] private GameObject _complexityPanel;//3
    [SerializeField] private GameObject _levelSizePanel;//4

    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private List<GameObject> _enemyList = new();

    private void Start()
    {
        _dropdown.onValueChanged.AddListener(ChangeEnemyAmount);
    }

    private void ChangeEnemyAmount(int amount)
    {
        Clear();

        AddUnits(amount);

        MoveBasePanels();
    }

    private void AddUnits(int amount)
    {
        for (int i = 0; i <= amount; i++)
        {
            var panel = Instantiate(_enemyPrefab, _content);
            _enemyList.Add(panel);
        }
    }

    private void Clear()
    {
        foreach (var item in _enemyList)
              Destroy(item);
        
        _enemyList.Clear();
    }

    private void MoveBasePanels()
    {
        _contestantPanel.transform.SetAsFirstSibling();
        _gameConfigPanel.transform.SetAsFirstSibling();

        _complexityPanel.transform.SetAsLastSibling();
        _levelSizePanel.transform.SetAsLastSibling();
    }
}
