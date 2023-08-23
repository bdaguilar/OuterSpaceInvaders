using UnityEngine;

public class GameInstaller : GeneralInstaller
{
    [SerializeField]
    private ShipInstaller _shipInstaller;
    [SerializeField]
    private EnemySpawner _enemySpawner;
    [SerializeField]
    private GameStateController _gameStateController;
    [SerializeField]
    private ScreenFade _screenFade;
    [SerializeField]
    private Menu _menu;
    [SerializeField]
    private PauseView _pauseMenu;
    [SerializeField]
    private GameOverView _gameOverView;
    [SerializeField]
    private GameVictoryView _gameVictoryView;

    protected override void DoInstalDependencies()
    {

    }

    protected override void DoStart()
    {
        ServiceLocator.Instance.RegisterService(_shipInstaller);
        ServiceLocator.Instance.RegisterService(_enemySpawner);
        ServiceLocator.Instance.RegisterService(_gameStateController);
        ServiceLocator.Instance.RegisterService(_screenFade);
        ServiceLocator.Instance.RegisterService(_menu);
        ServiceLocator.Instance.RegisterService(_pauseMenu);
        ServiceLocator.Instance.RegisterService(_gameOverView);
        ServiceLocator.Instance.RegisterService(_gameVictoryView);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.UnregisterService<ShipInstaller>();
        ServiceLocator.Instance.UnregisterService<EnemySpawner>();
        ServiceLocator.Instance.UnregisterService<GameStateController>();
        ServiceLocator.Instance.UnregisterService<ScreenFade>();
        ServiceLocator.Instance.UnregisterService<Menu>();
        ServiceLocator.Instance.UnregisterService<PauseView>();
        ServiceLocator.Instance.UnregisterService<GameOverView>();
        ServiceLocator.Instance.UnregisterService<GameVictoryView>();
    }
}