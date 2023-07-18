using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    private ProjectileId _projectileId;
    [SerializeField]
    private float _bulletLifeSpan;
    [SerializeField]
    protected float _speed;
    [SerializeField]
    protected Rigidbody2D _rigidbody2D;


    protected Transform _transform;
    public string Id => _projectileId.Value;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = transform;
        DoStart();
        StartCoroutine(DestroyIn(_bulletLifeSpan));
    }

    protected abstract void DoStart();

    private void FixedUpdate()
    {
        DoMove();
    }

    protected abstract void DoMove();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyProjectile();
    }

    private IEnumerator DestroyIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        DoDestroyIn();
        Destroy(gameObject);
    }

    protected abstract void DoDestroyIn();
}
