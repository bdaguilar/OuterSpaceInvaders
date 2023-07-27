using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int _heatlh = 100;

    private IShip _ship;

    public Teams Team { get; private set; }

    public void Configure(IShip ship, int configurationHealth, Teams team)
    {
        _ship = ship;
        _heatlh = configurationHealth;
        Team = team;
    }

    public void AddDamage(int amout)
    {
        _heatlh = Mathf.Max(0, _heatlh - amout);

        bool isDeath = _heatlh <= 0;
        _ship.OnDamgeReceived(isDeath);
    }
}


