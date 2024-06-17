using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMapButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private MapGenerator _mapGenerator;

    [SerializeField] private float _mapSide;
    private void Start()
    {
        _button.onClick.AddListener(GenerateMap);
    }
    private void GenerateMap()
    {
        _mapGenerator.GenerateMap(_mapSide);
    }
}
