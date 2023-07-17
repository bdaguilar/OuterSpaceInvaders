using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    private ProjectileId _projectileId;

    public string Id => _projectileId.Value;

}
