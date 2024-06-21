using UnityEngine;
using UnityEngine.UI;

public sealed class BuilderDebugComponent : MonoBehaviour
{
    [SerializeField] private Build _build;
    [SerializeField] private Button _button;

    void Start()
    {
        _build = GetComponent<Build>();
        _button.onClick.AddListener(Build);
    }

    public void Build()
    {
         print("build");
        _build.StartBuilding();
    }
}