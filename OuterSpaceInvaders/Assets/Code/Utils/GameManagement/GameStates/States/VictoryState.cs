using System;

public class VictoryState : IGameState
{
    private readonly GameFacade _gameFacade;

    public VictoryState(GameFacade gameFacade)
    {
        _gameFacade = gameFacade;
    }

    public void Start(Action<GameStates> onStateEndedCallback)
    {
        _gameFacade.StopBattle();
        EventQueue.Instance.EnqueueEvent(new EventData(EventIds.Victory));
    }

    public void Stop()
    {

    }
}

