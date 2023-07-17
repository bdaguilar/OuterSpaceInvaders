using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;

    private Transform _myTransform;
    private CheckLimits _checkLimits;
    private IShip _ship;

    public void Configure(IShip shipMediator, CheckLimits checkLimits)
    {
        _ship = shipMediator;
        _checkLimits = checkLimits;
    }

    private void Awake()
    {
        _myTransform = transform;
    }

    public void Move(Vector2 direction)
    {
        _myTransform.Translate(direction * (_speed * Time.deltaTime));
        _checkLimits.ClampFinalPosition();

    }
}


