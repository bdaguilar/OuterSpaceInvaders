using System;

public class VictoryState : IGameState
{
    private readonly ICommand _stopBattleCommand;

    public VictoryState(ICommand command)
    {
        _stopBattleCommand = command;
    }

    public void Start(Action<GameStates> onStateEndedCallback)
    {
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(_stopBattleCommand);
        ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.Victory));
    }

    public void Stop()
    {

    }
}

