using UnityEngine;

public class JsonUtilityAdapter : ISerializer
{
    public T FromJson<T>(string data)
    {
        return JsonUtility.FromJson<T>(data);
    }

    public string ToJson<T>(T data)
    {
        return JsonUtility.ToJson(data);
    }
}