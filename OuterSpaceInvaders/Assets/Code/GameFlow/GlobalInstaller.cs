using UnityEngine;

public class GlobalInstaller : GeneralInstaller
{
    protected override void DoStart()
    {
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("MenuScene"));
    }

    protected override void DoInstalDependencies()
    {
        ServiceLocator.Instance.RegisterService<CommandQueue>(CommandQueue.Instance);
    }
}
