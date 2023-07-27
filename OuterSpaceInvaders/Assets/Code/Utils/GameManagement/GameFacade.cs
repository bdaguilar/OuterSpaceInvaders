using UnityEngine;

public class GameFacade : MonoBehaviour
{
    [SerializeField]
    private ScreenFade _screenFade;
    [SerializeField]
    private ShipInstaller _shipInstaller;
    [SerializeField]
    private EnemySpawner _enemySpawner;
    [SerializeField]
    private GameStateController _gameStateController;

    public void StopBattle()
    {
        _screenFade.Show();
        _enemySpawner.StopAndReset();
    }

    public void StartBattle()
    {
        _gameStateController.Reset();
        ScoreView.Instance.Reset();
        _enemySpawner.StartSpawn();
        _shipInstaller.SpawnUserShip();
        _screenFade.Hide();
    }
}

