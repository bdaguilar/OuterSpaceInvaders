using System.Threading.Tasks;

public class StartBattleCommand : ICommand
{
    public async Task Execute()
    {
        await new ShowScreenFadeCommand().Execute();

        ServiceLocator.Instance.GetService<GameStateController>().Reset();
        ServiceLocator.Instance.GetService<IScoreSystem>().Reset();
        ServiceLocator.Instance.GetService<EnemySpawner>().StartSpawn();
        ServiceLocator.Instance.GetService<ShipInstaller>().SpawnUserShip();
        ServiceLocator.Instance.GetService<ScoreView>().Reset();

        await new HideScreenFadeCommand().Execute();
    }
}
