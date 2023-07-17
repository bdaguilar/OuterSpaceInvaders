using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInputAdapter : IInput
{
    public Vector2 GetDirection()
    {
        float horizontalDir = Input.GetAxis("Horizontal");
        float verticalDir = Input.GetAxis("Vertical");
        return new Vector2(horizontalDir, verticalDir);
    }

    public bool IsFireActionPressed()
    {
        return Input.GetButton("Fire1");
    }
}
