using UnityEngine;

[CreateAssetMenu]
public sealed class GameSessionScriptableObject : ScriptableObject
{
    [SerializeField] private GameSession _complexity;
    public GameSession complexity => _complexity;

    public void SetComplexity(GameSession complexity)
    {
        _complexity = complexity;
    }
}

