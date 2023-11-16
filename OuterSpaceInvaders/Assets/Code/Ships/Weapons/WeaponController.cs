using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
    [SerializeField]
    private Transform _projectileSpawnPoint;
    [SerializeField]
    private ProjectilesConfiguration _projectilesConfiguration;

    private ProjectileId _defaultProjjectileId;
    private float _fireRateInSeconds;
    private IShip _ship;
    private float _cooldownSecondsToBeAbleToShoot;
    private ProjectileFactory _projectileFactory;
    private string _activeProjjectileId;
    private Teams _team;

    private List<Projectile> _aliveProjectiles;

    private void Awake()
    {
        _projectileFactory = ServiceLocator.Instance.GetService<ProjectileFactory>();
        _aliveProjectiles = new List<Projectile>();
    }

    public void Configure(IShip shipMediator, ProjectileId defaultProjectileId, float fireRate, Teams team)
    {
        _ship = shipMediator;
        _defaultProjjectileId = defaultProjectileId;
        _activeProjjectileId = _defaultProjjectileId.Value;
        _fireRateInSeconds = fireRate;
        _team = team;
    }

    public void TryShoot()
    {
        _cooldownSecondsToBeAbleToShoot -= Time.deltaTime;
        if (_cooldownSecondsToBeAbleToShoot > 0)
        {
            return;
        }

        Shoot();
        
    }

    public void Shoot()
    {
        _cooldownSecondsToBeAbleToShoot = _fireRateInSeconds;
        Projectile projectile = _projectileFactory.Create(_projectileSpawnPoint, _activeProjjectileId, _team);
        projectile.OnRecycle += OnDestroyProjectile;
        _aliveProjectiles.Add(projectile);
    }

    private void OnDestroyProjectile(Projectile projectile)
    {
        _aliveProjectiles.Remove(projectile);
        projectile.OnRecycle -= OnDestroyProjectile;
    }

    internal void Restart()
    {
        foreach(Projectile projectile in _aliveProjectiles)
        {
            projectile.Recycle();
        }

        _aliveProjectiles.Clear();
    }
}

