using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPositionCheckLimits : CheckLimits
{
    private readonly Transform _transform;
    private readonly float _maxDistance;
    private readonly Vector3 _intialPosition;

    public InitialPositionCheckLimits(Transform transform, float maxDistance)
    {
        _transform = transform;
        _maxDistance = maxDistance;
        _intialPosition = _transform.position;
    }

    public void ClampFinalPosition()
    {
        Vector3 currentPosition = _transform.position;
        Vector3 finalPosition = currentPosition;
        float distance = Mathf.Abs(_intialPosition.x - currentPosition.x);
        if (distance > _maxDistance)
        {
            if(currentPosition.x > _intialPosition.x)
            {
                finalPosition.x = _intialPosition.x + _maxDistance;
            }
            else {
                finalPosition.x = _intialPosition.x - _maxDistance;
            }
        }
        _transform.position = finalPosition;
    }
}
