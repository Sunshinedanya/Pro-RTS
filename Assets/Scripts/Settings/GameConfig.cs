[System.Serializable]
public struct GameConfig
{
    public int height;
    public int width;
    public bool isFullScreen;

    public float volume;
    public bool mute;

    public GameConfig(int height, int width, bool isFullScreen, float volume, bool mute)
    {
        this.height = height;
        this.width = width;
        this.isFullScreen = isFullScreen;
        this.volume = volume;
        this.mute = mute;
    }

    public (int width, int height, bool fullscreen) GetResolutionConfig()
    {
        var config = (width, height, isFullScreen);
        return config;    
    }

    public (float volume, bool mute) GetVolumeConfig()
    {
        var config = (volume, mute);
        return config;
    }
}
