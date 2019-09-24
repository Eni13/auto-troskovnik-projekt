using System;

namespace CommonComponents
{
    public static class EventHelpers
    {

        public static void RaiseEvent<T>(Object objectRaisingEvent,
            EventHandler<T> eventHandlerRaised,
            T args)
        {
            eventHandlerRaised?.Invoke(objectRaisingEvent, args);
        }

        public static void RaiseEvent(Object objectRaisingEvent,
        EventHandler eventHandlerRaised,
        EventArgs eventArgs)
        {
            eventHandlerRaised?.Invoke(objectRaisingEvent, eventArgs);
        }
    }
}
