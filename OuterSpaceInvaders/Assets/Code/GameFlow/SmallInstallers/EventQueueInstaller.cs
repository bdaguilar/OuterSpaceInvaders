using UnityEngine;

public class EventQueueInstaller : Installer
{
    [SerializeField]
    private EventQueueImpl _eventQueue;

    public override void Install(ServiceLocator serviceLocator)
    {
        DontDestroyOnLoad(_eventQueue.gameObject);
        serviceLocator.RegisterService<IEventQueue>(_eventQueue);
    }
}