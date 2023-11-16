using System.Threading.Tasks;

public class LoadGameSceneCommand : ICommand
{
    public async Task Execute()
    {
        /*CompositeCommand compositeCommand = new CompositeCommand();
        compositeCommand.AddCommand(new LoadSceneCommand("GameScene"));
        compositeCommand.AddCommand(new StartBattleCommand());
        await compositeCommand.Execute();*/
        await new LoadSceneCommand("GameScene").Execute();
        await new StartBattleFromMenuCommand().Execute();
    }
}
