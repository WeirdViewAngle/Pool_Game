using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static Dictionary<EventsNames, List<IntEventInvoker>> invokers = 
        new Dictionary<EventsNames, List<IntEventInvoker>>();

    static Dictionary<EventsNames, List<UnityAction<int>>> listeners =
        new Dictionary<EventsNames, List<UnityAction<int>>>();


    public static void Initialize()
    {
        foreach(EventsNames eventName in Enum.GetValues(typeof(EventsNames)))
        {
            if (!invokers.ContainsKey(eventName))
            {
                invokers.Add(eventName, new List<IntEventInvoker>());
                listeners.Add(eventName, new List<UnityAction<int>>());
            }
            else
            {
                invokers[eventName].Clear();
                listeners[eventName].Clear();
            }
        }

    }


    public static void AddInvoker(EventsNames eventName, IntEventInvoker intInvoker)
    {
        foreach(UnityAction<int> listener in listeners[eventName])
        {
            intInvoker.AddListener(eventName, listener);
        }
        invokers[eventName].Add(intInvoker);
    }

    public static void AddListener(EventsNames eventName, UnityAction<int> listener)
    {
        foreach(IntEventInvoker invoker in invokers[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        listeners[eventName].Add(listener);
    }

    public static void RemoveInvoker(EventsNames eventName, IntEventInvoker intInvoker)
    {
        if (invokers.ContainsKey(eventName))
        {
            invokers[eventName].Remove(intInvoker);
        }
    }

    public static void RemoveListener(EventsNames eventName, UnityAction<int> listener)
    {
        if (listeners.ContainsKey(eventName))
        {
            listeners[eventName].Remove(listener);
        }
    }
}
