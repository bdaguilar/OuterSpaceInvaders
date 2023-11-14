using System;
using System.Threading.Tasks;

public class RestartGameCommand : ICommand
{
    public async Task Execute()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.RestartGame));
        await new ResumeGameCommand().Execute();
        await new StopGameCommand().Execute();
        await new StartBattleFromMenuCommand().Execute();
    }
}

