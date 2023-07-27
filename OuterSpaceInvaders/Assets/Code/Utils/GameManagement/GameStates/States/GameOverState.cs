using System;

public class GameOverState : IGameState
{
    private readonly GameFacade _gameFacade;

    public GameOverState(GameFacade gameFacade)
    {
        _gameFacade = gameFacade;
    }

    public void Start(Action<GameStates> onStateEndedCallback)
    {
        _gameFacade.StopBattle();
        EventQueue.Instance.EnqueueEvent(new EventData(EventIds.GameOver));
    }

    public void Stop()
    {

    }
}

