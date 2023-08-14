using System;

public class PlayingState : IGameState, IEventObserver
{
    private int _aliveShips;
    private bool _allShipsSpawned = false;
    private Action<GameStates> _onStatedEndedCallback;

    public void Start(Action<GameStates> onStatedEndedCallback)
    {
        _onStatedEndedCallback = onStatedEndedCallback;
        _aliveShips = 0;
        _allShipsSpawned = false;
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.ShipDestroyed, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.ShipSpawned, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.AllShipsSpawned, this);
    }

    public void Stop()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.ShipDestroyed, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.ShipSpawned, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.AllShipsSpawned, this);
    }

    public void Process(EventData eventData)
    {
        if (eventData.EventId == EventIds.ShipDestroyed)
        {
            _aliveShips--;
            ShipDestroyedEventData shipDestroyedEventData = (ShipDestroyedEventData)eventData;

            if (shipDestroyedEventData.Team == Teams.Ally)
            {
                _onStatedEndedCallback.Invoke(GameStates.GameOver);
                return;
            }

        }
        else if (eventData.EventId == EventIds.ShipSpawned)
        {
            _aliveShips++;
        }
        else if (eventData.EventId == EventIds.AllShipsSpawned)
        {
            _allShipsSpawned = true;
        }

        CheckGameState();
    }

    private void CheckGameState()
    {
        if (_aliveShips == 0 && _allShipsSpawned == true)
        {
            _onStatedEndedCallback.Invoke(GameStates.Victory);
        }
    }
}

