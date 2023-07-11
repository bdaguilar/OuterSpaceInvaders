using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDataStoreAdapter : IDataStore
{
    public T GetData<T>(string name)
    {
        string json = PlayerPrefs.GetString(name);
        return JsonUtility.FromJson<T>(json);
    }

    public void SetData<T>(T data, string name)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(name, json);
        PlayerPrefs.Save();
    }
}
