using System.Threading.Tasks;

public class HideScreenFadeCommand : ICommand
{
    public async Task Execute()
    {
        ServiceLocator.Instance.GetService<ScreenFade>().Hide();
        await Task.Delay(200);
    }
}