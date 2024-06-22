using System.IO;
using UnityEngine;

public abstract class ConfigurableScriptableObject : ScriptableObject
{
    public abstract void Load();
    public abstract void Save();
}

public abstract class ConfigurableScriptableObject<T> : ConfigurableScriptableObject
{
    [SerializeField] protected string path;
    [SerializeField] private T _dataElement;
    public T dataElement => _dataElement;
    public override void Load()
    {
        if (File.Exists(path))
        {
            var data = File.ReadAllText(path);
            _dataElement = JsonUtility.FromJson<T>(data);
        }
        else
        {
            Save();
        }

    }

    public override void Save()
    {
        if (string.IsNullOrEmpty(path))
            path = SerializeHelper.CreatePath(nameof(T));
        SerializeHelper.SerialiseAndSave(path, _dataElement);
    }
}

