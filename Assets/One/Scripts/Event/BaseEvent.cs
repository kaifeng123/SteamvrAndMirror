using Common;
using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEvent : MonoBehaviour
{
    public EventCode eventCode;

    public abstract void OnEvent(EventData eventData);


    public virtual void Start()
    {
        PtotonEngine.Instance.AddEvent(this);
    }

    public void OnDestroy()
    {
        PtotonEngine.Instance.RemoverEvent(this);
    }
}
