using System;

public class VictoryState : IGameState
{ 
    public void Start(Action<GameStates> onStateEndedCallback)
    {
        ServiceLocator.Instance.GetService<IGameFacade>().StopBattle();
        ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.Victory));
    }

    public void Stop()
    {

    }
}

