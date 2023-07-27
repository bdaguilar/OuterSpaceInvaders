using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/Ship/Create Ships Configuration", fileName = "ShipsConfiguration", order = 0)]
public class ShipsConfiguration : ScriptableObject
{
    [SerializeField]
    private ShipMediator[] _shipsIdPrefabs;

    private Dictionary<string, ShipMediator> _idShipPrefab;

    private void Awake()
    {
        _idShipPrefab = new Dictionary<string, ShipMediator>();
        foreach (ShipMediator ship in _shipsIdPrefabs)
        {
            _idShipPrefab.Add(ship.Id, ship);
        }
    }

    public ShipMediator GetShipById(string id)
    {
        if (!_idShipPrefab.TryGetValue(id, out var ship))
        {
            throw new Exception($"ship {id} not found");
        }

        return ship;
    }
}


