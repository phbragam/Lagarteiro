using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// I can use this kind of event when I need to passa a Game Object in the event
[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> { }


public class EventListener : MonoBehaviour
{
    public Event gEvent;
    public UnityEvent response;

    public void OnEventRaised()
    {
        response.Invoke();
    }

    private void OnEnable()
    {
        gEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gEvent.DeRegisterListener(this);
    }
}
