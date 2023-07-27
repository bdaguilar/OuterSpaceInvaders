using System;
using UnityEngine;

public class CheckBottomLimitsStrategy : ICheckDestroyLimits
{
    private readonly Camera _mainCamera;

    public CheckBottomLimitsStrategy(Camera camera)
    {
        _mainCamera = camera;
    }

    public bool IsInsideTheLimits(Vector3 position)
    {
        Vector3 viewportPoint = _mainCamera.WorldToViewportPoint(position);
        return viewportPoint.y > 0;
    }
}

