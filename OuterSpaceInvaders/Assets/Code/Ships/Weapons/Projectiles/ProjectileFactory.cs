using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory
{
	private readonly ProjectilesConfiguration _projectilesConfiguration;
	private readonly Dictionary<string, ObjectPool> _pools;

	public ProjectileFactory(ProjectilesConfiguration projectilesConfiguration)
	{
		_projectilesConfiguration = projectilesConfiguration;

		Projectile[] projectiles = _projectilesConfiguration.ProjectilePrefabs;

        _pools = new Dictionary<string, ObjectPool>(projectiles.Length);

        foreach (Projectile projectile in projectiles)
		{
			ObjectPool objectPool = new ObjectPool(projectile);
			_pools.Add(projectile.Id, objectPool);
			objectPool.Init(15);
		}
	}

	public Projectile Create(Transform spawnPoint, string id, Teams team)
	{
		Projectile prefab = _projectilesConfiguration.GetProjectileById(id);

		Projectile projectile =_pools[id].Spawn<Projectile>(spawnPoint.position, spawnPoint.rotation);
        projectile.Configure(team);

		return projectile;

    }
}

