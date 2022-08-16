using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ConfigLoader
{
    public static List<T> LoadList<T>()
    {
        var commonDictionariesPath = Path.Combine(Application.dataPath, Constants.Common.DictionariesPath);
        var path = Path.Combine(commonDictionariesPath, $"{typeof(T)}.json");
        if (!File.Exists(path))
        {
            File.Create(path);
        }
        var fieldData = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path), Constants.Common.JsonSerializerSettings);
        
        if (fieldData == null || fieldData.Count == 0)
        {
            fieldData = new List<T>();
        }
        
        return fieldData;
    }

    public static T Load<T>()
    {
        var commonDictionariesPath = Path.Combine(Application.dataPath, Constants.Common.DictionariesPath);
        var path = Path.Combine(commonDictionariesPath, $"{typeof(T)}.json");
        if (!File.Exists(path))
        {
            File.Create(path);
        }
        var fieldData = JsonConvert.DeserializeObject<T>(File.ReadAllText(path), Constants.Common.JsonSerializerSettings);
        return fieldData;
    }

    public static void Save<T>(List<T> config)
    {
        var commonDictionariesPath = Path.Combine(Application.dataPath, Constants.Common.DictionariesPath);
        var path = Path.Combine(commonDictionariesPath, $"{typeof(T)}.json");
        File.WriteAllText(path, JsonConvert.SerializeObject(config, Constants.Common.JsonSerializerSettings));
    }

    public static void Save<T>(T config)
    {
        var commonDictionariesPath = Path.Combine(Application.dataPath, Constants.Common.DictionariesPath);
        var path = Path.Combine(commonDictionariesPath, $"{typeof(T)}.json");
        File.WriteAllText(path, JsonConvert.SerializeObject(config, Constants.Common.JsonSerializerSettings));
    }
}
