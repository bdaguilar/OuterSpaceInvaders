﻿using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private Transform[] _spawnPositions;
	[SerializeField]
	private LevelConfiguration _levelConfiguration;
	[SerializeField]
	private ShipsConfiguration _shipsConfiguration;

	private ShipFactory _shipFactory;

	private float _currentTimeInSeconds;
	private int _currentConfigurationIndex;
    private bool _canSpawn = false;
	private List<ShipMediator> _spawnedEnemies;

    private void Awake()
    {
		_shipFactory = ServiceLocator.Instance.GetService<ShipFactory>();
		_spawnedEnemies = new List<ShipMediator>();
    }

    public void StartSpawn()
    {
		_canSpawn = true;
    }

    public void StopAndReset()
    {
		_canSpawn = false;
		_currentTimeInSeconds = 0f;
		_currentConfigurationIndex = 0;
    }

    private void Update()
    {
		if(!_canSpawn)
		{
			return;
		}

		if(_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
		{
			return;
		}

        _currentTimeInSeconds += Time.deltaTime;

        SpawnConfiguration spawnConfiguration = _levelConfiguration.SpawnConfigurations[_currentConfigurationIndex];
		if(spawnConfiguration.TimeToSpawn > _currentTimeInSeconds)
		{
			return;
		}

		SpawnShips(spawnConfiguration);
		_currentConfigurationIndex++;

        if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
        {
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.AllShipsSpawned));
        }
    }

    private void SpawnShips(SpawnConfiguration spawnConfiguration)
    {
		for(int i = 0; i < spawnConfiguration.ShipToSpawnConfigurations.Length; i++)
		{
			ShipToSpawnConfiguration shipToSpawnConfiguration = spawnConfiguration.ShipToSpawnConfigurations[i];
			Transform spawnPosition = _spawnPositions[i % _spawnPositions.Length];
            ShipBuilder shipBuilder =_shipFactory.Create(shipToSpawnConfiguration.ShipId.Value);
			ShipMediator ship = shipBuilder.WithInputMode(ShipBuilder.InputMode.Ai)
				.WithPosition(spawnPosition.position)
				.WithRotation(spawnPosition.rotation)
				.WithCheckLimitsType(ShipBuilder.CheckLimitsTypes.InitialPosition)
				.WithConfiguration(shipToSpawnConfiguration)
				.WithTeams(Teams.Enemy)
				.WithCheckDestroyLimits()
				.Build();
            ship.OnRecycle += OnDestroyShip;
            _spawnedEnemies.Add(ship);
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.ShipSpawned));
        }
    }

    private void OnDestroyShip(ShipMediator ship)
    {
        _spawnedEnemies.Remove(ship);
        ship.OnRecycle -= OnDestroyShip;
    }

    public void Restart()
	{
        foreach (ShipMediator ship in _spawnedEnemies)
        {
            ship.Recycle();
        }

        _spawnedEnemies.Clear();
    }
}

