using UnityEngine;

public class ScoreViewInstaller : Installer
{
	[SerializeField]
	private ScoreView _scoreView;

    public override void Install(ServiceLocator serviceLocator)
    {
        serviceLocator.RegisterService<IScoreSystem>(_scoreView);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.UnregisterService<IScoreSystem>();
    }
}

