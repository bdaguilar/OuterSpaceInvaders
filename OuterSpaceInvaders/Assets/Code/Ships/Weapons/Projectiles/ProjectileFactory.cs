using UnityEngine;

public class ProjectileFactory
{
	private readonly ProjectilesConfiguration _projectilesConfiguration;

	public ProjectileFactory(ProjectilesConfiguration projectilesConfiguration)
	{
		_projectilesConfiguration = projectilesConfiguration;
	}

	public Projectile Create(Transform spawnPoint, string id, Teams team)
	{
		Projectile prefab = _projectilesConfiguration.GetProjectileById(id);
        Projectile projectile = Object.Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        projectile.Configure(team);

		return projectile;

    }
}

