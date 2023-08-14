using UnityEngine;

public class GameFacadeImpl : MonoBehaviour, IGameFacade
{

    public void StopBattle()
    {
        ServiceLocator.Instance.GetService<LoadingScreen>().Show();
        ServiceLocator.Instance.GetService<EnemySpawner>().StopAndReset();
    }

    public void StartBattle()
    {
        ServiceLocator.Instance.GetService<GameStateController>().Reset();
        ServiceLocator.Instance.GetService<IScoreSystem>().Reset();
        ServiceLocator.Instance.GetService<EnemySpawner>().StartSpawn();
        ServiceLocator.Instance.GetService<ShipInstaller>().SpawnUserShip();
        ServiceLocator.Instance.GetService<LoadingScreen>().Hide();
    }
}