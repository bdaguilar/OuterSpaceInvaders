using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Projectile : RecyclableObject, IDamageable
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

    public Action<Projectile> OnRecycle;

    public void Configure(Teams team)
    {
        Team = team;
    }

    internal override void Init()
    {
        DoStart();
        StartCoroutine(RecycleIn(_bulletLifeSpan));
    }

    internal override void Release()
    {
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = transform;
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

    private IEnumerator RecycleIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        RecycleProjectile();
    }

    private void RecycleProjectile()
    {
        OnRecycle?.Invoke(this);
        Recycle();
    }

    public void AddDamage(int amout)
    {
        RecycleProjectile();
    }
}
