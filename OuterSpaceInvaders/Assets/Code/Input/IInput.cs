using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    Vector2 GetDirection();
    bool IsFireActionPressed();
}
