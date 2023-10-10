using System;

public interface ISerializer
{
    string ToJson<T>(T data);
    T FromJson<T>(string data);
}