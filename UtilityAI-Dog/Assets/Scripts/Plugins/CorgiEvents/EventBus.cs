using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CorgiTools.CorgiEvents
{
    public static class EventBus<T> where T : IEvent
    {
        static readonly HashSet<IEventBinding<T>> bindings = new HashSet<IEventBinding<T>>();

        public static void Register(EventBinding<T> binding) => bindings.Add(binding);
        public static void Unregister(EventBinding<T> binding) => bindings.Remove(binding);

        public static void Raise(T _event)
        {
            foreach (var binding in bindings)
            {
                binding.OnEvent.Invoke(_event);
                binding.OnEventNoArgs.Invoke();
            }
        }

        static void Clear()
        {
            Debug.Log($"Clearing {typeof(T).Name} binding");
            bindings.Clear();
        }
    }
}
