using UnityEngine;

public class ShipConfiguration
{
	public readonly IInput Input;
	public readonly CheckLimits CheckLimits;
	public readonly ICheckDestroyLimits CheckDestroyLimits;

	public readonly Vector2 Speed;
    public readonly int Health;
    public readonly float FireRate;
	public readonly ProjectileId DefaultProjectileId;
	public readonly Teams Team;
	public readonly int Score;

    public ShipConfiguration(IInput input, CheckLimits checkLimits,
                             ICheckDestroyLimits checkDestroyLimits,
                             Vector2 speed, int health, float fireRate,
							 ProjectileId defaultProjectileId, Teams team, int score)
	{
		Input = input;
		CheckLimits = checkLimits;
        CheckDestroyLimits = checkDestroyLimits;
        Speed = speed;
		Health = health;
		FireRate = fireRate;
		DefaultProjectileId = defaultProjectileId;
		Team = team;
		Score = score;
	}
}


