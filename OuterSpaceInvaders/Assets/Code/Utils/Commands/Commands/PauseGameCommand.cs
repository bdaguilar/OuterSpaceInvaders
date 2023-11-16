using System.Threading.Tasks;
using UnityEngine;

public class PauseGameCommand : ICommand
{
    public Task Execute()
    {
        Time.timeScale = 0;
        return Task.CompletedTask;
    }
}