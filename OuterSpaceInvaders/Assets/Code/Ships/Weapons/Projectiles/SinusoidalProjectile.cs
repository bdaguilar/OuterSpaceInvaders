using System.Collections;
using UnityEngine;

public class SinusoidalProjectile : Projectile
{
    [SerializeField]
    private float _amplitude;
    [SerializeField]
    private float _frequency;

    private Vector3 _currentPosition;
    private float _currentTime;

    protected override void DoStart()
    {
        _currentPosition = _transform.position;
        _currentTime = 0;
    }

    protected override void DoMove()
    {
        _currentPosition += _transform.up * (_speed * Time.deltaTime);
        Vector3 horizontalPosition = _transform.right * (_amplitude * Mathf.Sin(_currentTime * _frequency));
        _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);

        _currentTime += Time.deltaTime;
    }

    protected override void DoDestroyIn()
    {
    }
}


