using UnityEngine;
using UnityEngine.UI;

public class UnitFactoryDebugComponent : MonoBehaviour
{
    [SerializeField] private UnitFactory _unitFactory;
    [SerializeField] private Button _button;

    public GameObject _unitPrefab;

    private void Start()
    {
        _button.onClick.AddListener(Spawn);
    }

    public void Spawn()
    {
        _unitFactory.SpawnUnit(_unitPrefab);
    }
}
