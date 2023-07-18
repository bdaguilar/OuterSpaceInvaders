using System.Collections;
using UnityEngine;


public class LinealProjectile : Projectile
{
    protected override void DoStart()
    {
        _rigidbody2D.velocity = _transform.up * _speed;
    }

    protected override void DoMove()
    {
    }

    protected override void DoDestroyIn()
    {
    }
}


