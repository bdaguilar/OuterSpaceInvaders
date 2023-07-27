using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewportCheckLimits : CheckLimits
{
    private readonly Camera _mainCamera;
    private readonly float _minTreshold;
    private readonly float _maxTreshold;

    public ViewportCheckLimits(Transform transform, Camera camera, float minTreshold, float maxTreshold)
    {
        _mainCamera = camera;
        _minTreshold = minTreshold;
        _maxTreshold = maxTreshold;
    }

    public Vector2 ClampFinalPosition(Vector2 currentPosition)
    {
        Vector3 viewportPoint = _mainCamera.WorldToViewportPoint(currentPosition);
        viewportPoint.x = Mathf.Clamp(viewportPoint.x, _minTreshold, _maxTreshold);
        viewportPoint.y = Mathf.Clamp(viewportPoint.y, _minTreshold, _maxTreshold);
        return _mainCamera.ViewportToWorldPoint(viewportPoint);
    }
}
