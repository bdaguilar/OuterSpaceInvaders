using System;
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

    private void Awake()
    {
        _projectileFactory = new ProjectileFactory(Instantiate(_projectilesConfiguration));
        
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
        _projectileFactory.Create(_projectileSpawnPoint, _activeProjjectileId, _team);
    }
}

