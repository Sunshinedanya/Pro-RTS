using System;
using System.IO;
using UnityEngine;

public class ConfigSaver : MonoBehaviour, ISerializationCallbackReceiver
{
    private readonly string _fileName = "Settings.json";
    private string path;

    [SerializeField] private ResolutionChanger _resolutionChanger;
    [SerializeField] private VolumeChanger _volumeChanger;

    private GameConfig _currentConfig;
    [SerializeField] private GameConfigScriptableObject _currentScriptableObject;

    private void Start()
    {
        path = Path.Combine(Application.dataPath, _fileName);
    }

    public void Save()
    {
        var save = GetConfig();
        
        var json = JsonUtility.ToJson(save);
        
        File.WriteAllText(path, json);

        _currentConfig = save;
    }

    public void Load()
    {
        var json = File.ReadAllText(path);
        var save = JsonUtility.FromJson<GameConfig>(json);

        _currentConfig = save;
    }

    public GameConfig GetConfig()
    {
        if(_resolutionChanger == null)
            throw new ArgumentException();

        if(_volumeChanger == null)
            throw new ArgumentException();

        var resConfig = _resolutionChanger.GetConfig();
        var volumeConfig = _volumeChanger.GetConfig();

        var save = new GameConfig(resConfig.height, resConfig.width, resConfig.fullscreen, volumeConfig.volume, volumeConfig.mute);

        return save;
    }

    private void FillChangers()
    {
        var volumeConfig = _currentConfig.GetVolumeConfig();
        var resolutionConfig = _currentConfig.GetResolutionConfig();

        _resolutionChanger.SetConfig(resolutionConfig);
        _volumeChanger.SetConfig(volumeConfig);
    }

    public void OnBeforeSerialize()
    {
        throw new NotImplementedException();
    }

    public void OnAfterDeserialize()
    {
        throw new NotImplementedException();
    }
}