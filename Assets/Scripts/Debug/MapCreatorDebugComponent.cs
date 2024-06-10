using UnityEngine;
using UnityEngine.UI;

public sealed class MapCreatorDebugComponent : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private MapCreator _mapCreator;

    [SerializeField] private float _mapSide;
    private void Start()
    {
        _button.onClick.AddListener(GenerateMap);
    }

    private void GenerateMap()
    {
        _mapCreator.GenerateMap(_mapSide);
    }
}

