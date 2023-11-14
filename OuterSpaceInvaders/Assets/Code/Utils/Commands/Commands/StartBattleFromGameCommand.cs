using System.Threading.Tasks;

public class StartBattleFromGameCommand : ICommand
{
    public async Task Execute()
    {
        ServiceLocator.Instance.GetService<GameStateController>().Reset();
        ServiceLocator.Instance.GetService<IScoreSystem>().Reset();
        ServiceLocator.Instance.GetService<EnemySpawner>().StartSpawn();
        ServiceLocator.Instance.GetService<ShipInstaller>().SpawnUserShip();
        ServiceLocator.Instance.GetService<ScoreView>().Reset();
        //await ServiceLocator.Instance.GetService<ShipFactory>().RecycleAllPools();
        //ServiceLocator.Instance.GetService<InGameMenuView>().HideAllViews();
    }
}