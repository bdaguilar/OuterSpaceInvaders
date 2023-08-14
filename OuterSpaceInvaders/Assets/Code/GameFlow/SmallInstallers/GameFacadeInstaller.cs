using System;
using UnityEngine;

public class GameFacadeInstaller : Installer
{
    [SerializeField]
    private GameFacadeImpl _gameFacade;

    public override void Install(ServiceLocator serviceLocator)
    {
        serviceLocator.RegisterService<IGameFacade>(_gameFacade);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.UnregisterService<IGameFacade>();
    }
}
