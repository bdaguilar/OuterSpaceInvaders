using System.Collections;
using UnityEngine;

public class CurveProjectile : Projectile
{
    [SerializeField]
    private AnimationCurve _horizontalPosition;

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
        Vector3 horizontalPosition = _transform.right * _horizontalPosition.Evaluate(_currentTime);
        _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);

        _currentTime += Time.deltaTime;
    }
}


