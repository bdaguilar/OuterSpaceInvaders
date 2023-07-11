using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInstaller : MonoBehaviour
{
    [SerializeField]
    private bool _useAI = false;
    [SerializeField]
    private bool _useJoystick = false;
    [SerializeField]
    private Joystick _joystick;
    [SerializeField]
    private Ship _ship;
    [SerializeField]
    private float _maxDistance;
    [SerializeField]
    private float _minTreshold;
    [SerializeField]
    private float _maxTreshold;

    private void Awake()
    {
        _joystick = GameObject.FindObjectOfType<Joystick>();
        _ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Ship>();
        _ship.Configure(GetInput(), GetCheckLimits());
    }

    private CheckLimits GetCheckLimits()
    {
        if (_useAI)
        {
            return new InitialPositionCheckLimits(_ship.transform, _maxDistance);
        }

        return new ViewportCheckLimits(_ship.transform, Camera.main, _minTreshold, _maxTreshold);
    }

    private IInput GetInput()
    {
        /*#if UNITY_EDITOR
                return new JoystickIInputAdapter(_joystick);
        #else
            return new JoystickIInputAdapter(_joystick);
        #endif*/

        if (_useAI)
        {
            return new AIInputAdapter(_ship);
        }

        if (_useJoystick)
        {
            return new JoystickIInputAdapter(_joystick);
        }
            
        Destroy(_joystick.gameObject);
        return new UnityInputAdapter();

    }
}
