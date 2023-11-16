using System;
using System.Threading.Tasks;

public class StopGameCommand : ICommand
{
    public async Task Execute()
    {
        ServiceLocator.Instance.GetService<EnemySpawner>().StopAndReset();
        ServiceLocator.Instance.GetService<EnemySpawner>().Restart();
        await Task.Yield();
    }
}
