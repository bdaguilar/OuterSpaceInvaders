using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataStoreAdapter : IDataStore
{
    public T GetData<T>(string name)
    {
        string path = Path.Combine(Application.dataPath + "/Persistence", name);
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<T>(json);
    }

    public void SetData<T>(T data, string name)
    {
        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.dataPath + "/Persistence", name);
        File.WriteAllText(path, json);
    }
}
