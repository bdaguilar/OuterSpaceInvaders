using System.Collections.Generic;
using UnityEngine;

public class EventQueueImpl : MonoBehaviour, IEventQueue
{
    private class RemoveData
    {
        public EventIds EventId;
        public IEventObserver EventObserver;

        public RemoveData(EventIds eventId, IEventObserver eventObserver)
        {
            EventId = eventId;
            EventObserver = eventObserver;
        }
    }

    private List<RemoveData> _observersToUnsubscribe;
    private Queue<EventData> _currentEvents;
    private Queue<EventData> _nextEvents;

	private Dictionary<EventIds, List<IEventObserver>> _observers;
    private bool _isProccessingEvents;

    private void Awake()
    {
        _observersToUnsubscribe = new List<RemoveData>();
        _currentEvents = new Queue<EventData>();
        _nextEvents = new Queue<EventData>();
        _observers = new Dictionary<EventIds, List<IEventObserver>>();
    }

    public void Subscribe(EventIds eventId, IEventObserver eventObserver)
    {
        if(!_observers.TryGetValue(eventId, out var eventObservers))
        {
            eventObservers = new List<IEventObserver>();
        }

        eventObservers.Add(eventObserver);
        _observers[eventId] = eventObservers;
    }

    public void Unsubscribe(EventIds eventId, IEventObserver eventObserver)
    {
        if (_isProccessingEvents)
        {
            RemoveData removeData = new RemoveData(eventId, eventObserver);
            _observersToUnsubscribe.Add(removeData);
            return;
        }

        DoUnsubscribe(eventId, eventObserver);
    }

    private void DoUnsubscribe(EventIds eventId, IEventObserver eventObserver)
    {
        _observers[eventId].Remove(eventObserver);
    }

    public void EnqueueEvent(EventData eventData)
    {
        _nextEvents.Enqueue(eventData);
    }

    private void LateUpdate()
    {
        ProcessEvents();
    }

    public void ProcessEvents()
    {
        Queue<EventData> tempCurrentEvents = _currentEvents;
        _currentEvents = _nextEvents;
        _nextEvents = tempCurrentEvents;

        foreach(EventData currentEvent in _currentEvents)
        {
            ProcessEvent(currentEvent);
        }

        _currentEvents.Clear();
    }

    private void ProcessEvent(EventData eventData)
    {
        _isProccessingEvents = true;
        if (_observers.TryGetValue(eventData.EventId, out var eventObservers))
        {
            foreach (IEventObserver eventObserver in eventObservers)
            {
                eventObserver.Process(eventData);
            }
        }
        _isProccessingEvents = false;
        UnsubscribePendingObservers();
    }

    private void UnsubscribePendingObservers()
    {
        foreach (RemoveData removeData in _observersToUnsubscribe)
        {
            DoUnsubscribe(removeData.EventId, removeData.EventObserver);
        }
    }
}