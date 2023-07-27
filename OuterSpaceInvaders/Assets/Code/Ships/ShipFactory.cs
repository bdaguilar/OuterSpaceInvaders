using UnityEngine;

public class ShipFactory
{
    private readonly ShipsConfiguration _shipsConfiguration;

    public ShipFactory(ShipsConfiguration shipsConfiguration)
    {
        _shipsConfiguration = shipsConfiguration;
    }

    public ShipBuilder Create(string id)
    {
        ShipMediator prefab = _shipsConfiguration.GetShipById(id);

        return new ShipBuilder()
            .FromPrefab(prefab);
    }
}


