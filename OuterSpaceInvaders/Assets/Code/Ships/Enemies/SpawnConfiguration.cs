﻿using System;
using UnityEngine;

[Serializable]
public class SpawnConfiguration
{
	[SerializeField]
	private ShipToSpawnConfiguration[] _shipToSpawnConfigurations;
	[SerializeField]
	private float _timeToSpawn;

	public ShipToSpawnConfiguration[] ShipToSpawnConfigurations => _shipToSpawnConfigurations;
	public float TimeToSpawn => _timeToSpawn;
}


