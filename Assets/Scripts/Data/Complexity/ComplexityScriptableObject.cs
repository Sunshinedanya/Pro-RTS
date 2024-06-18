using UnityEngine;

public sealed class ComplexityScriptableObject : ScriptableObject
{
    [SerializeField] private Complexity _complexity;
    public Complexity complexity => _complexity;

    public void SetComplexity(Complexity complexity)
    {
        _complexity = complexity;
    }
}

