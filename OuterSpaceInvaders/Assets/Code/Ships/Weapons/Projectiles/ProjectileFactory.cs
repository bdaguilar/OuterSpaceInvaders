using UnityEngine;

public class ProjectileFactory
{
	private readonly ProjectilesConfiguration _projectilesConfiguration;

	public ProjectileFactory(ProjectilesConfiguration projectilesConfiguration)
	{
		_projectilesConfiguration = projectilesConfiguration;
	}

	public Projectile Create(Transform spawnPoint, string id)
	{
		Projectile prefab = _projectilesConfiguration.GetProjectile(id);

		return Object.Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
	}
}

