using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Vector2 _speed;
    private Rigidbody2D _rigidbody2D;
    private CheckLimits _checkLimits;
    private IShip _ship;

    private Vector2 _currentPosition;

    public void Configure(IShip shipMediator, CheckLimits checkLimits, Vector2 speed)
    {
        _ship = shipMediator;
        _checkLimits = checkLimits;
        _speed = speed;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _currentPosition = _rigidbody2D.position;
    }

    public void Move(Vector2 direction)
    {
        _currentPosition += direction * (_speed * Time.deltaTime);
        _currentPosition = _checkLimits.ClampFinalPosition(_currentPosition);
        _rigidbody2D.MovePosition(_currentPosition);
        

    }
}


