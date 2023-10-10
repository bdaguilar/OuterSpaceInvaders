using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDataStoreAdapter : IDataStore
{
    private readonly ISerializer _serializer;

    public PlayerPrefsDataStoreAdapter(ISerializer serializer)
    {
        _serializer = serializer;
    }

    public T GetData<T>(string name)
    {
        string json = PlayerPrefs.GetString(name);
        return _serializer.FromJson<T>(json);
    }

    public void SetData<T>(T data, string name)
    {
        string json = _serializer.ToJson(data);
        PlayerPrefs.SetString(name, json);
        PlayerPrefs.Save();
    }
}
