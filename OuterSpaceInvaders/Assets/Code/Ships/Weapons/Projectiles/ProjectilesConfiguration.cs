using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/Projectile/Create Projectiles Configuration", fileName = "ProjectilesConfiguration", order = 0)]
public class ProjectilesConfiguration : ScriptableObject
{
    [SerializeField]
    private Projectile[] _projectilesIdPrefabs;

    private Dictionary<string, Projectile> _idToProjectilePrefab;

    private void Awake()
    {
        _idToProjectilePrefab = new Dictionary<string, Projectile>();
        foreach(Projectile projectile in _projectilesIdPrefabs)
        {
            _idToProjectilePrefab.Add(projectile.Id, projectile);
        }
    }

    public Projectile GetProjectile(string id)
    {
        if(!_idToProjectilePrefab.TryGetValue(id, out var projectile))
        {
            throw new Exception($"Projectile {id} not found");
        }

        return projectile;
    }
}

