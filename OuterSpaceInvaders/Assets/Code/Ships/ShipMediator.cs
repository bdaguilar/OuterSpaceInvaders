using System;
using UnityEngine;

[RequireComponent(typeof(WeaponController))]
[RequireComponent(typeof(MovementController))]
public class ShipMediator : MonoBehaviour, IShip
{
    [SerializeField]
    private WeaponController _weaponController;
    [SerializeField]
    private MovementController _movementController;

    private IInput _inputController;

    private void Awake()
    {
        _weaponController = GetComponent<WeaponController>();
        _movementController = GetComponent<MovementController>();
    }

    public void Configure(IInput input, CheckLimits checkLimits)
    {
        _inputController = input;
        _weaponController.Configure(this);
        _movementController.Configure(this, checkLimits);
    }

    private void Update()
    {
        _movementController.Move(_inputController.GetDirection());
        TryShoot();
    }

    private void TryShoot()
    {
        if (_inputController.IsFireActionPressed())
        {
            _weaponController.TryShoot();
        }
    }
}


