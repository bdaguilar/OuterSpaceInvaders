using System;
using UnityEngine;

public class DoNotCheckDestroyLimitsStrategy : ICheckDestroyLimits
{
    public bool IsInsideTheLimits(Vector3 position)
    {
        return true;
    }
}
