using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntEventInvoker : MonoBehaviour
{
    public Dictionary<EventsNames, UnityEvent<int>> dictOfInvokers =
        new Dictionary<EventsNames, UnityEvent<int>>();

    public void AddListener(EventsNames eventName, UnityAction<int> listener)
    {
        if (dictOfInvokers.ContainsKey(eventName))
        {
            dictOfInvokers[eventName].AddListener(listener);
        }
    }
}
