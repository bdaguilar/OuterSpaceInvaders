using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputAdapter : IInput
{
    private float _minTreshold = 0.05f;
    private float _maxTreshold = 0.95f;
    private Transform _shipTransform;
    private Camera _mainCamera;
    private ShipMediator _ship;
    private float _currentDirectionX;

    public AIInputAdapter(ShipMediator ship)
    {
        _ship = ship;
        _currentDirectionX = 1;
        _shipTransform = _ship.transform;
        _mainCamera = Camera.main;
    }

    public Vector2 GetDirection()
    {
        Vector3 currentPos = _mainCamera.WorldToViewportPoint(_shipTransform.position);
        if(currentPos.x > _maxTreshold)
        {
            _currentDirectionX = _shipTransform.right.x;
        }else if(currentPos.x < _minTreshold)
        {
            _currentDirectionX = -_shipTransform.right.x;
        }

        return new Vector2(_currentDirectionX, -1);
    }

    public bool IsFireActionPressed()
    {
        return Random.Range(0, 100) < 20;
    }
}
