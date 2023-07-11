using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputAdapter : IInput
{
    private float _minTreshold = 0.05f;
    private float _maxTreshold = 0.95f;
    private Transform _shipTransform;
    private Camera _mainCamera;
    private readonly Ship _ship;
    private int _currentDirectionX;

    public AIInputAdapter(Ship ship)
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
            _currentDirectionX = -1;
        }else if(currentPos.x < _minTreshold)
        {
            _currentDirectionX = 1;
        }

        return new Vector2(_currentDirectionX, 0);
    }
}
