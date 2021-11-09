﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace HelperClasses.Event_System
{
    [DefaultExecutionOrder(-100)]
    public class EventManager
    {
        private static EventManager Instance = null;
        private static EventManager currentInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new EventManager();
                }
                return Instance;
            }
        }

        public delegate void EventListener(EventInfo eventInfo);
        public Dictionary<Type, EventListener> eventListeners { get; private set; }
        public static void RegisterListener<T>(EventListener eventListener) where T : EventInfo
        {
            if (currentInstance.eventListeners == null)
            {
                currentInstance.eventListeners = new Dictionary<Type, EventListener>();
            }

            if (!currentInstance.eventListeners.ContainsKey(typeof(T)) || currentInstance.eventListeners[typeof(T)] == null)
            {
                currentInstance.eventListeners[typeof(T)] = eventListener;
                return;
            }

            currentInstance.eventListeners[typeof(T)] += eventListener;
        }

        public static void UnregisterListener<T>(EventListener listener) where T : EventInfo
        {
            if (currentInstance.eventListeners == null)
            {
                return;
            }

            if (currentInstance.eventListeners.ContainsKey(typeof(T)) && currentInstance.eventListeners[typeof(T)] != null)
            {
                currentInstance.eventListeners[typeof(T)] -= (listener);
            }
        }

        public static void SendNewEvent(EventInfo eventInfo)
        {
            Type eventType = eventInfo.GetType();

            if (currentInstance.eventListeners == null || !currentInstance.eventListeners.ContainsKey(eventType) || currentInstance.eventListeners[eventType] == null)
            {
                return;
            }

            currentInstance.eventListeners[eventType](eventInfo);
        }
        
        
        

       
        /*
    Register Listerner:
    EventManager.RegisterEventListerner<TypeOfEvent>(Method);
      EventManager.RegisterEventListerner<OtherTypeOfEvent>(Method);

    Unregister Listerner:
    EventManager.UnregisterEventListerner(<EventInfo>, Method)


    TypeOfEventInfp Toei = new TypeOfEvent();
    EventMagener.SendNewEvent(Toei);

    Method(EventInfo ei)
    {
        TypeOfEventInfo Toei = (TypeOfEventInfo)ei;
    }
    */
    
    
    }
}

