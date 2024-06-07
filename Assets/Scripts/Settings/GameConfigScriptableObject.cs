using UnityEngine;

[CreateAssetMenu]
public class GameConfigScriptableObject : ScriptableObject
{
    public int height;
    public int width;
    public bool isFullscreen;
    public float volume;
    public bool mute;

    public void SetConfig(GameConfig config)
    {
        height = config.height;
        width = config.width;
        isFullscreen = config.isFullscreen;
        volume = config.volume;
        mute = config.mute;
    }

    public GameConfig GetConfig()
    {
        var config = new GameConfig(height, width, isFullscreen, volume, mute);
        return config;
    }
}
