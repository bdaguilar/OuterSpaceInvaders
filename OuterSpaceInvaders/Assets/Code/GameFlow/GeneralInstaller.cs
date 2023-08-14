using System;
using UnityEngine;

public abstract class GeneralInstaller : MonoBehaviour
{
    [SerializeField]
    private Installer[] _installers;

    private void Awake()
    {
        InstallDependencies();
    }

    private void Start()
    {
        DoStart();
    }

    abstract protected void DoStart();

    abstract protected void DoInstalDependencies();

    private void InstallDependencies()
    {
        foreach (Installer installer in _installers)
        {
            installer.Install(ServiceLocator.Instance);
        }
        DoInstalDependencies();
    }
}

