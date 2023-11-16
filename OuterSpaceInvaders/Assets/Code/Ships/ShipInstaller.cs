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
    private ShipToSpawnConfiguration _shipConfiguration;
    [SerializeField]
    private ShipsConfiguration _shipsConfiguration;

    private ShipBuilder _shipBuilder;

    private void Awake()
    { 
        _joystick = GameObject.FindObjectOfType<Joystick>();
        _joyButton = GameObject.FindGameObjectWithTag("FireButton").GetComponent<JoyButton>();
        ShipFactory shipFactory = ServiceLocator.Instance.GetService<ShipFactory>();
        _shipBuilder = shipFactory.Create(_shipConfiguration.ShipId.Value)
            .WithConfiguration(_shipConfiguration)
            .WithTeams(Teams.Ally);

        SetCheckLimits(_shipBuilder);
        SetInput(_shipBuilder);
    }

    public void SpawnUserShip()
    {
        _shipBuilder.Build();
    }

    private void SetCheckLimits(ShipBuilder shipBuilder)
    {
        if (_useAI)
        {
            shipBuilder.WithCheckLimitsType(ShipBuilder.CheckLimitsTypes.InitialPosition);
            return;
        }

        shipBuilder.WithCheckLimitsType(ShipBuilder.CheckLimitsTypes.Viewport);
    }

    private void SetInput(ShipBuilder shipBuilder)
    {
        /*#if UNITY_EDITOR
                return new JoystickIInputAdapter(_joystick);
        #else
            return new JoystickIInputAdapter(_joystick);
        #endif*/

        if (_useAI)
        {
            shipBuilder.WithInputMode(ShipBuilder.InputMode.Ai);
            return;
        }

        if (_useJoystick)
        {
            shipBuilder.WithInputMode(ShipBuilder.InputMode.Joystick)
                .WithJoysticks(_joystick, _joyButton);
            return;
        }
            
        Destroy(_joystick.gameObject);
        Destroy(_joyButton.gameObject);
        shipBuilder.WithInputMode(ShipBuilder.InputMode.Unity);

    }
}
