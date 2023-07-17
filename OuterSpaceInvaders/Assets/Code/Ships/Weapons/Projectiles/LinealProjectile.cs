using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LinealProjectile : Projectile
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private float _bulletLifeSpan;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _rigidbody2D.velocity = _transform.up * _speed;
        StartCoroutine(DestroyIn(_bulletLifeSpan));
    }

    private IEnumerator DestroyIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}


