using System;
using System.Threading.Tasks;

public class ResetScoreViewCommand : ICommand
{
    public Task Execute()
    {
        ServiceLocator.Instance.GetService<IScoreSystem>().Reset();
        return Task.CompletedTask;
    }
}