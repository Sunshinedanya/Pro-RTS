using System;
using System.IO;
using UnityEngine;

public static class SerializeHelper
{
    public static string CreatePath(string file)
    {
        var path = Application.dataPath;

        var name = file + ".json";

        return Path.Combine(path, name);
    }

    public static void SerialiseAndSave<T>(string path, T obj)
    {
        var data = JsonUtility.ToJson(obj,true);

        File.WriteAllText(path, data);
    }
}