using UnityEngine;

[CreateAssetMenu]
public class GameConfigScriptableObject : ScriptableObject
{
    public int height;
    public int width;
    public bool isFullScreen;
    public float volume;
    public bool mute;

    public void SetConfig(GameConfig config)
    {
        height = config.height;
        width = config.width;
        isFullScreen = config.isFullScreen;
        volume = config.volume;
        mute = config.mute;
    }
}
