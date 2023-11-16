using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCommand : ICommand
{
    private readonly string _sceneToLoad;

    public LoadSceneCommand(string sceneToLoad)
    {
        _sceneToLoad = sceneToLoad;
    }

    public async Task Execute()
    {
        LoadingScreen loadingScreen = ServiceLocator.Instance.GetService<LoadingScreen>();
        loadingScreen.Show();
        await LoadScene(_sceneToLoad);
        await Task.Delay(2000);
        loadingScreen.Hide();
    }

    private async Task LoadScene(string name)
    {
        AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(name);

        while (!loadSceneAsync.isDone)
        {
            await Task.Yield();
        }
        await Task.Yield();
    }
}
