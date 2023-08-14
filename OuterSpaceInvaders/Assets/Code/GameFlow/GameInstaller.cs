using UnityEngine;

public class GameInstaller : GeneralInstaller
{
    [SerializeField]
    private ShipInstaller _shipInstaller;
    [SerializeField]
    private EnemySpawner _enemySpawner;
    [SerializeField]
    private GameStateController _gameStateController;

    protected override void DoInstalDependencies()
    {

    }

    protected override void DoStart()
    {
        ServiceLocator.Instance.RegisterService(_shipInstaller);
        ServiceLocator.Instance.RegisterService(_enemySpawner);
        ServiceLocator.Instance.RegisterService(_gameStateController);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.UnregisterService<ShipInstaller>();
        ServiceLocator.Instance.UnregisterService<EnemySpawner>();
        ServiceLocator.Instance.UnregisterService<GameStateController>();
    }
}