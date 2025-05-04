using System;
using System.Collections.Generic;

namespace RedBall50.Scripts.Managers
{
    public static class EventManager
    {
        public static event Action<object, EventArgs>? Collected;

        public static event Action<object, EventArgs>? EnemyDestroyed;

        public static event Action<object, EventArgs>? StarAchieved;

        public static event Action<object, EventArgs>? LevelClaimed;

        private static Dictionary<Type, List<Action<object, EventArgs>>> _events
        { get; set; } = default!;

        private static Dictionary<Type, List<Action<object, EventArgs>>> Events
        {
            get
            {
                _events ??= new()
                {
                    { typeof(EventArgs), new()
                        { Collected, EnemyDestroyed, StarAchieved, LevelClaimed } }
                };

                return _events;
            }
        }

        public static void EventCallback<TEventArgs>(
            object sender, TEventArgs eventArgs) where TEventArgs : EventArgs
        {
            UnityEngine.Debug.Log(
                $"[EventCallback] {typeof(TEventArgs)}, [From] : {sender.GetType()}");
            if (Events.TryGetValue(typeof(TEventArgs), out var events))
            {
                foreach (var e in events)
                {
                    e?.Invoke(sender, eventArgs);
                }
            }
        }

        public static void OnCollected(object sender, EventArgs eventArgs)
        {
            Collected?.Invoke(sender, eventArgs);
        }

        public static void OnEnemyDestroyed(object sender, EventArgs eventArgs)
        {
            EnemyDestroyed?.Invoke(sender, eventArgs);
        }

        public static void OnStarAchieved(object sender, EventArgs eventArgs)
        {
            StarAchieved?.Invoke(sender, eventArgs);
        }

        public static void OnLevelClaimed(object sender, EventArgs eventArgs)
        {
            LevelClaimed?.Invoke(sender, eventArgs);
        }
    }
}
