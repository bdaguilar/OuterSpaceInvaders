using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShip
{
    string Id { get; }

    void OnDamgeReceived(bool isDeath);
}
