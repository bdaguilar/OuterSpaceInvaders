using System;

public class GameOverState : IGameState
{
    public void Start(Action<GameStates> onStateEndedCallback)
    {
        ServiceLocator.Instance.GetService<IGameFacade>().StopBattle();
        ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.GameOver));
    }

    public void Stop()
    {

    }
}

