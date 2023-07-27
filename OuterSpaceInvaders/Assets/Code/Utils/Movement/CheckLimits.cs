using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CheckLimits
{
    Vector2 ClampFinalPosition(Vector2 _currentPosition);
}
