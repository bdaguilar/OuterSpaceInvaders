using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private float _fireRateInSeconds;
    [SerializeField]
    private Transform _projectileSpawnPoint;
    [SerializeField]
    private ProjectileId _defaultProjjectileId;
    [SerializeField]
    private ProjectilesConfiguration _projectilesConfiguration;
    

    private IShip _ship;
    private float _cooldownSecondsToBeAbleToShoot;
    private ProjectileFactory _projectileFactory;
    private string _activeProjjectileId;

    private void Awake()
    {
        _projectileFactory = new ProjectileFactory(Instantiate(_projectilesConfiguration));
        _activeProjjectileId = _defaultProjjectileId.Value;
    }

    public void Configure(IShip shipMediator)
    {
        _ship = shipMediator;
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
        _projectileFactory.Create(_projectileSpawnPoint, _activeProjjectileId);
    }
}

