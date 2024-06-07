using System;

[Serializable]
public struct GameConfig 
{
    public int height;
    public int width;
    public bool isFullscreen;
    public float volume;
    public bool mute;

    public GameConfig(int height, int width, bool isFullscreen, float volume, bool mute)
    {
        this.height = height;
        this.width = width;
        this.isFullscreen = isFullscreen;
        this.volume = volume;
        this.mute = mute;
    }
    public (int width, int height, bool fullscreen) GetResolutionConfig()
    {
        var config = (width, height, isFullscreen);
        return config;    
    }
    public (float volume, bool mute) GetVolumeConfig()
    {
        var config = (volume, mute);
        return config;
    }
    public void SetConfig(GameConfigScriptableObject config)
    {
        this.height = config.height;
        this.width = config.width;
        this.isFullscreen = config.isFullscreen;
        this.volume = config.volume;
        this.mute = config.mute;
    }
}
