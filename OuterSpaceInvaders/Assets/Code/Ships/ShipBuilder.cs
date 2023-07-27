using System;
using UnityEngine;
using UnityEngine.Assertions;

public class ShipBuilder
{
    public enum InputMode
    {
        Unity,
        Joystick,
        Ai
    }

    public enum CheckLimitsTypes
    {
        InitialPosition,
        Viewport
    }

    private ShipMediator _prefab;
	private Vector3 _position = Vector3.zero;
	private Quaternion _rotation = Quaternion.identity;
    private IInput _input;
    private CheckLimits _checkLimits;
    private ShipToSpawnConfiguration _shipConfiguration;
    private InputMode _inputMode;
    private Joystick _joystick;
    private JoyButton _joyButton;
    private CheckLimitsTypes _checkLimitsTypes;
    private Teams _team;
    private ICheckDestroyLimits _checkDestroyLimits = new DoNotCheckDestroyLimitsStrategy();

    public ShipBuilder FromPrefab(ShipMediator prefab)
	{
		_prefab = prefab;
		return this;
	}

    public ShipBuilder WithPosition(Vector3 position)
    {
        _position = position;
        return this;
    }

	public ShipBuilder WithRotation(Quaternion rotation)
	{
		_rotation = rotation;
		return this;
	}

    public ShipBuilder WithInput(IInput input)
	{
		_input = input;
		return this;
	}

    public ShipBuilder WithInputMode(InputMode inputMode)
    {
        _inputMode = inputMode;
        return this;
    }

    public ShipBuilder WithCheckLimits(CheckLimits checkLimits)
    {
        _checkLimits = checkLimits;
        return this;
    }

    public ShipBuilder WithConfiguration(ShipToSpawnConfiguration shipConfiguration)
    {
        _shipConfiguration = shipConfiguration;
        return this;
    }

    public ShipBuilder WithJoysticks(Joystick joystick, JoyButton joyButton)
    {
        _joystick = joystick;
        _joyButton = joyButton;
        return this;
    }

    public ShipBuilder WithCheckLimitsType(CheckLimitsTypes checkLimitsTypes)
    {
        _checkLimitsTypes = checkLimitsTypes;
        return this;
    }

    public ShipBuilder WithTeams(Teams team)
    {
        _team = team;
        return this;
    }

    public ShipBuilder WithCheckDestroyLimits()
    {
        _checkDestroyLimits = new CheckBottomLimitsStrategy(Camera.main);
        return this;
    }

    public ShipMediator Build()
	{
		ShipMediator ship = UnityEngine.Object.Instantiate(_prefab, _position, _rotation);
        ShipConfiguration shipConfiguration = new ShipConfiguration(GetInput(ship),
                                                                    GetCheckLimits(ship),
                                                                    _checkDestroyLimits,
                                                                    _shipConfiguration.Speed,
                                                                    _shipConfiguration.Health,
                                                                    _shipConfiguration.FireRate,
                                                                    _shipConfiguration.DefaultProjectileId,
                                                                    _team,
                                                                    _shipConfiguration.Score);
        ship.Configure(shipConfiguration);
        return ship;
	}

    private IInput GetInput(ShipMediator shipMediator)
    {
        if(_input != null)
        {
            return _input;
        }

        switch (_inputMode)
        {
            case InputMode.Unity:
                return new UnityInputAdapter();
            case InputMode.Joystick:
                Assert.IsNotNull(_joystick);
                Assert.IsNotNull(_joyButton);
                return new JoystickIInputAdapter(_joystick, _joyButton);
            case InputMode.Ai:
                return new AIInputAdapter(shipMediator);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private CheckLimits GetCheckLimits(ShipMediator shipMediator)
    {
        if (_checkLimits != null)
        {
            return _checkLimits;
        }

        switch (_checkLimitsTypes)
        {
            case CheckLimitsTypes.InitialPosition:
                return new InitialPositionCheckLimits(shipMediator.transform, 25);
            case CheckLimitsTypes.Viewport:
                return new ViewportCheckLimits(shipMediator.transform, Camera.main, 0.03f, 0.97f);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}


