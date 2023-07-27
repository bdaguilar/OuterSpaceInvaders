using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/Ship/Create ShipId", fileName = "ShipId", order = 0)]
public class ShipId : ScriptableObject
{
    [SerializeField]
    private string _value;

    public string Value => _value;
}

