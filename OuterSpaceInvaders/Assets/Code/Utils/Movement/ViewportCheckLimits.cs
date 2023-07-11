using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewportCheckLimits : CheckLimits
{
    private readonly Camera _mainCamera;
    private readonly Transform _transform;
    private readonly float _minTreshold;
    private readonly float _maxTreshold;

    public ViewportCheckLimits(Transform transform, Camera camera, float minTreshold, float maxTreshold)
    {
        _transform = transform;
        _mainCamera = camera;
        _minTreshold = minTreshold;
        _maxTreshold = maxTreshold;
    }

    public void ClampFinalPosition()
    {
        Vector3 viewportPoint = _mainCamera.WorldToViewportPoint(_transform.position);
        viewportPoint.x = Mathf.Clamp(viewportPoint.x, _minTreshold, _maxTreshold);
        viewportPoint.y = Mathf.Clamp(viewportPoint.y, _minTreshold, _maxTreshold);
        _transform.position = _mainCamera.ViewportToWorldPoint(viewportPoint);
    }
}
