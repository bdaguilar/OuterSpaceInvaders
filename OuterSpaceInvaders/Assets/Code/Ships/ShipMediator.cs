using System;
using UnityEngine;

[RequireComponent(typeof(WeaponController))]
[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(HealthController))]
public class ShipMediator : RecyclableObject, IShip, IEventObserver
{
    [SerializeField]
    private WeaponController _weaponController;
    [SerializeField]
    private MovementController _movementController;
    [SerializeField]
    private HealthController _healthController;
    [SerializeField]
    private ShipId _shipId;
    [SerializeField]
    private GameObject _explotionAnimation;

    private IInput _inputController;
    private ICheckDestroyLimits _checkDestroyLimits;
    public string Id => _shipId.Value;
    private Teams _team;
    private int _score;
    private Transform _transform;
    private int _amountToSpawn;

    public Action<ShipMediator> OnRecycle;

    private void Awake()
    {
        _weaponController = GetComponent<WeaponController>();
        _movementController = GetComponent<MovementController>();
        _healthController = GetComponent<HealthController>();
        _transform = transform;
    }

    internal override void Init()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.GameOver, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.Victory, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.RestartGame, this);
    }

    internal override void Release()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.GameOver, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.Victory, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.RestartGame, this);
    }

    public void Configure(ShipConfiguration shipConfiguration)
    {
        _team = shipConfiguration.Team;
        _score = shipConfiguration.Score;
        _inputController = shipConfiguration.Input;
        _weaponController.Configure(this, shipConfiguration.DefaultProjectileId, shipConfiguration.FireRate, _team);
        _movementController.Configure(this, shipConfiguration.CheckLimits, shipConfiguration.Speed);
        _healthController.Configure(this, shipConfiguration.Health, _team);
        _checkDestroyLimits = shipConfiguration.CheckDestroyLimits;
    }

    private void FixedUpdate()
    {
        _movementController.Move(_inputController.GetDirection());
    }

    private void Update()
    {
        TryShoot();
        CheckDestroyLimits();
    }

    private void CheckDestroyLimits()
    {
        if (_checkDestroyLimits.IsInsideTheLimits(_transform.position))
        {
            return;
        }

        RecycleShip();

        ShipDestroyedEventData shipDestroyedEventData = new ShipDestroyedEventData(0, _team, GetInstanceID());
        ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(shipDestroyedEventData);
    }

    private void TryShoot()
    {
        if (_inputController.IsFireActionPressed())
        {
            _weaponController.TryShoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if(damageable.Team == _team)
        {
            return;
        }
        damageable.AddDamage(1);
    }

    public void OnDamgeReceived(bool isDeath)
    {
        if(isDeath)
        {
            Instantiate(_explotionAnimation, _transform.position, Quaternion.identity);
            RecycleShip();

            ShipDestroyedEventData shipDestroyedEventData = new ShipDestroyedEventData(_score, _team, GetInstanceID());
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(shipDestroyedEventData);
        }
    }

    public void Process(EventData eventData)
    {
        if (eventData.EventId != EventIds.GameOver &&
            eventData.EventId != EventIds.Victory &&
            eventData.EventId != EventIds.RestartGame)
        {
            return;
        }

        _weaponController.Restart();

        RecycleShip();
    }

    private void RecycleShip()
    {
        OnRecycle?.Invoke(this);
        Recycle();
    }
}


