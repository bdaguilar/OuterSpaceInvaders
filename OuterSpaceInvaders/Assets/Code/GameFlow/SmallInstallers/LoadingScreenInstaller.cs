using UnityEngine;

public class LoadingScreenInstaller : Installer
{
    [SerializeField]
    private LoadingScreen _loadingScreen;

    public override void Install(ServiceLocator serviceLocator)
    {
        DontDestroyOnLoad(_loadingScreen.gameObject);
        serviceLocator.RegisterService<LoadingScreen>(_loadingScreen);
    }
}
