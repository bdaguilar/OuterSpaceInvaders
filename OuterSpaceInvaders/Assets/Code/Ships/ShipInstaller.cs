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
    private JoyButton _joyButton;
    [SerializeField]
    private ShipMediator _shipMediator;
    [SerializeField]
    private float _maxDistance;
    [SerializeField]
    private float _minTreshold;
    [SerializeField]
    private float _maxTreshold;

    private void Awake()
    {
        _joystick = GameObject.FindObjectOfType<Joystick>();
        _joyButton = GameObject.FindGameObjectWithTag("FireButton").GetComponent<JoyButton>();
        _shipMediator = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipMediator>();
        _shipMediator.Configure(GetInput(), GetCheckLimits());
    }

    private CheckLimits GetCheckLimits()
    {
        if (_useAI)
        {
            return new InitialPositionCheckLimits(_shipMediator.transform, _maxDistance);
        }

        return new ViewportCheckLimits(_shipMediator.transform, Camera.main, _minTreshold, _maxTreshold);
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
            return new AIInputAdapter(_shipMediator);
        }

        if (_useJoystick)
        {
            return new JoystickIInputAdapter(_joystick, _joyButton);
        }
            
        Destroy(_joystick.gameObject);
        Destroy(_joyButton.gameObject);
        return new UnityInputAdapter();

    }
}
