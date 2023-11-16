using System.Threading.Tasks;

public class ShowScreenFadeCommand : ICommand
{
    public async Task Execute()
    {
        ServiceLocator.Instance.GetService<ScreenFade>().Show();
        await Task.Delay(200);
    }
}

