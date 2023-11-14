using System;
using System.Threading.Tasks;

public class GameOverState : IGameState
{
    private readonly ICommand _stopBattleCommand;

    public GameOverState(ICommand command)
    {
        _stopBattleCommand = command;
    }

    public void Start(Action<GameStates> onStateEndedCallback)
    {
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(_stopBattleCommand);
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new PauseGameCommand());
        ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.GameOver));
    }

    public void Stop()
    {

    }
}

