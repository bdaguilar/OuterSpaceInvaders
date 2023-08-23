using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Projectile : MonoBehaviour, IDamageable
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

    public Teams Team { get; private set; }

    public Action<Projectile> OnDestroy;

    public void Configure(Teams team)
    {
        Team = team;
    }

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
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if(damageable.Team == Team)
        {
            return;
        }
        damageable.AddDamage(1);
    }

    private IEnumerator DestroyIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        DoDestroyIn();
        OnDestroy?.Invoke(this);
        Destroy(gameObject);
    }

    protected abstract void DoDestroyIn();

    public void AddDamage(int amout)
    {
        DestroyProjectile();
    }
}
