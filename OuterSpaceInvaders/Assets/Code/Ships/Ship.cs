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

    private void Awake()
    {
        _myTransform = transform;
        _mainCamera = Camera.main;
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
        ClampFinalPosition();
        
    }

    private void ClampFinalPosition()
    {
        Vector3 viewportPoint = _mainCamera.WorldToViewportPoint(_myTransform.position);
        viewportPoint.x = Mathf.Clamp(viewportPoint.x, _minTreshold, _maxTreshold);
        viewportPoint.y = Mathf.Clamp(viewportPoint.y, _minTreshold, _maxTreshold);
        _myTransform.position = _mainCamera.ViewportToWorldPoint(viewportPoint);
    }

    private Vector2 GetDirection()
    {
        float horizontalDir = Input.GetAxis("Horizontal");
        float verticalDir = Input.GetAxis("Vertical");
        return new Vector2(horizontalDir, verticalDir);
    }
}
