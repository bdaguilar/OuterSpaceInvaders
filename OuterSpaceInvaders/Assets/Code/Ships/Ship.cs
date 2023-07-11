using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;
    [SerializeField]
    private float _minTreshold = 0.03f;
    [SerializeField]
    private float _maxTreshold = 0.97f;
    

    private Transform _myTransform;
    private Camera _mainCamera;
    private IInput _inputController;
    private CheckLimits _checkLimits;

    private void Awake()
    {
        _myTransform = transform;
        _mainCamera = Camera.main;
    }

    public void Configure(IInput input, CheckLimits checkLimits)
    {
        _inputController = input;
        _checkLimits = checkLimits;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = GetDirection();
        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        _myTransform.Translate(direction * (_speed * Time.deltaTime));
        _checkLimits.ClampFinalPosition();
        
    }

    private Vector2 GetDirection()
    {
        return _inputController.GetDirection();
    }
}
