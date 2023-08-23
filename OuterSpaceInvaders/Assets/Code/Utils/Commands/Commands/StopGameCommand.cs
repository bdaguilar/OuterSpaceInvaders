using System;
using System.Threading.Tasks;

public class StopGameCommand : ICommand
{
    public Task Execute()
    {
        ServiceLocator.Instance.GetService<EnemySpawner>().StopAndReset();
        return Task.CompletedTask;
    }
}
