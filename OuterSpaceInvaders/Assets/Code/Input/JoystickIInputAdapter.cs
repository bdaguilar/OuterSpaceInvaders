using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickIInputAdapter : IInput
{
    private readonly Joystick _joystick;

    public JoystickIInputAdapter(Joystick joystick)
    {
        _joystick = joystick;
    }

    public Vector2 GetDirection()
    {
        return new Vector2(_joystick.Horizontal, _joystick.Vertical);
    }
}
