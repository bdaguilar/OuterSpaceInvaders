using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class ObjectPool
{
    private readonly RecyclableObject _prefab;
    private readonly HashSet<RecyclableObject> _instantiateObjects;
    private Queue<RecyclableObject> _recycleObjects;

    public ObjectPool(RecyclableObject prefab)
    {
        _prefab = prefab;
        _instantiateObjects = new HashSet<RecyclableObject>();
    }

    public void Init(int numberOfInitialObjects)
    {
        _recycleObjects = new Queue<RecyclableObject>(numberOfInitialObjects);

        for(int i = 0; i < numberOfInitialObjects; i++)
        {
            RecyclableObject instance = InstantiateNewInstance(Vector3.zero, Quaternion.identity);
            instance.gameObject.SetActive(false);
            _recycleObjects.Enqueue(instance);
        }
    }

    private RecyclableObject InstantiateNewInstance(Vector3 position, Quaternion rotation)
    {
        RecyclableObject instance = Object.Instantiate(_prefab, position, rotation);
        instance.Configure(this);
        return instance;
    }

    public T Spawn<T>(Vector3 position, Quaternion rotation)
    {
        RecyclableObject recyclableObject = GetInstance(position, rotation);
        _instantiateObjects.Add(recyclableObject);
        recyclableObject.gameObject.SetActive(true);
        recyclableObject.Init();
        return recyclableObject.GetComponent<T>();
    }

    private RecyclableObject GetInstance(Vector3 position, Quaternion rotation)
    {
        if(_recycleObjects.Count > 0)
        {
            RecyclableObject recyclableObject = _recycleObjects.Dequeue();
            Transform transform = recyclableObject.transform;
            transform.position = position;
            transform.rotation = rotation;
            return recyclableObject;
        }

        Debug.LogWarning($"Not enough recycled objects for {_prefab.name} consider increasing the inistial number of objects to create");
        RecyclableObject instance = InstantiateNewInstance(position, rotation);
        return instance;
    }

    public void RecycleGameObject(RecyclableObject gameObjectToRecycle)
    {
        bool wasInstantiated = _instantiateObjects.Remove(gameObjectToRecycle);
        Assert.IsTrue(wasInstantiated, $"{gameObjectToRecycle.name} was not instantiated on {_instantiateObjects} initially");

        gameObjectToRecycle.gameObject.SetActive(false);
        gameObjectToRecycle.Release();
        _recycleObjects.Enqueue(gameObjectToRecycle);
    }

}