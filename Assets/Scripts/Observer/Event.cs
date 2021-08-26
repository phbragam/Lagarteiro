using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class Event : ScriptableObject
{
    public List<EventListener> eListeners = new List<EventListener>();

    public void EventOccurred()
    {
        for (int i = eListeners.Count - 1; i >= 0; i--)
        {
            eListeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(EventListener listener)
    {
        eListeners.Add(listener);
    }

    public void DeRegisterListener(EventListener listener)
    {
        eListeners.Remove(listener);
    }
    
}
