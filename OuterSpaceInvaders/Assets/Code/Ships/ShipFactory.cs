using System.Collections.Generic;
using UnityEngine;

public class ShipFactory
{
    private readonly ShipsConfiguration _shipsConfiguration;

    private readonly Dictionary<string, ObjectPool> _pools;

    public ShipFactory(ShipsConfiguration shipsConfiguration)
    {
        _shipsConfiguration = shipsConfiguration;
        ShipMediator[] prefabs =  _shipsConfiguration.ShipPrefabs;
        _pools = new Dictionary<string, ObjectPool>(prefabs.Length);
        foreach(ShipMediator shipMediator in prefabs)
        {
            ObjectPool objectPool = new ObjectPool(shipMediator);
            objectPool.Init(10);
            _pools.Add(shipMediator.Id, objectPool);
        }
    }

    public ShipBuilder Create(string id)
    {
        ShipMediator prefab = _shipsConfiguration.GetShipById(id);

        return new ShipBuilder()
            .FromObjectPool(_pools[id]);
    }
}


