using System.Collections.Generic;
using System.Threading.Tasks;

public class CompositeCommand : ICommand
{
    private readonly List<ICommand> _commands;

    public CompositeCommand()
    {
        _commands = new List<ICommand>();
    }

    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public async Task Execute()
    {
        List<Task> tasks = new List<Task>(_commands.Count);
        foreach(ICommand command in _commands)
        {
            Task task = command.Execute();
            tasks.Add(task);
        }

        await Task.WhenAll(tasks);
    }
}

