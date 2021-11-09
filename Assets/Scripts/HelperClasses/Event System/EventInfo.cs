using HelperClasses.Event_System;
using UnityEngine;

namespace HelperClasses.Event_System
{
    public class EventInfo
    {
        public GameObject GO { get; private set; }
        public string Description { get; private set; }

        public EventInfo(GameObject senderObject = null, string description = "")
        {
            GO = senderObject;
            Description = description;
        }
    }
}


public class OnPlayerJumpEvent : EventInfo
{
    public OnPlayerJumpEvent(GameObject gO, string description): base(gO, description)
    {
        // The player has Jumped . We might Want to cancel Stuff or Implement smth . 
    }
}

public class OnPlayerMonkeyBarSwingEvent : EventInfo
{
    public OnPlayerMonkeyBarSwingEvent(GameObject gO, string description): base(gO, description)
    {
        // The player Swinging on A MonkeyBar. 
    }
}

public class OnPlayerMonkeyBarRelease : EventInfo
{
    public OnPlayerMonkeyBarRelease(GameObject gO, string description): base(gO, description)
    {
        // Player Calling To be released , MonkeyBar is Listening and will release if its same player Attached . 
    }
}



/*
public class ParameterExampleEventInfo : EventInfo
{
    public int ID{ get; private set; }
    public Transform Parent{ get; private set; }
    public ParameterExampleEventInfo(int id, Transform parent, GameObject senderObject, string description) : base(senderObject, description){
        ID = id;
        Parent = parent;
    }
}

public class SimpleExampleInfoEventInfo : EventInfo
{
    public SimpleExampleInfoEventInfo(GameObject gO, string description): base(gO, description)
    {
    }
}


Sample Way to use is the following : 

Class that register to a event will do it as written here 
EventManager.RegisterListener<SimpleExampleInfoEventInfo>(FunctionToCall);

    void FunctionToCall(EventInfo ei)
    {
        var initEvent = (SimpleExampleInfoEventInfo) ei;
        Debug.Log("My name is : "+ ei.GO.gameObject.name);
    }
    
Class That sends the event will call it as following 
        SimpleExampleInfoEventInfo SimpleEvent = new SimpleExampleInfoEventInfo(gameObject, "");
        EventManager.SendNewEvent(SimpleEvent);
*/