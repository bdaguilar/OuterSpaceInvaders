﻿using System.Collections.Generic;
using UnityEngine;

public class EventQueueImpl : MonoBehaviour, IEventQueue
{
    private Queue<EventData> _currentEvents;
    private Queue<EventData> _nextEvents;

	private Dictionary<EventIds, List<IEventObserver>> _observers;

    private void Awake()
    {
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

        /*if(_nextEvents.Count > 0)
        {
            ProcessEvents();
        }*/
    }

    private void ProcessEvent(EventData eventData)
	{
		if(_observers.TryGetValue(eventData.EventId, out var eventObservers))
        {
            foreach(IEventObserver eventObserver in eventObservers)
            {
                eventObserver.Process(eventData);
            }
        }
	}
}