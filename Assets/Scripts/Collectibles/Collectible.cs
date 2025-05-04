using System;
using RedBall50.Scripts.Managers;
using UnityEngine;

namespace RedBall50.Scripts.Collectibles
{
    public abstract class Collectible : MonoBehaviour
    {
        public event Action<object, EventArgs>? Collected;

        protected virtual void Awake()
        {
            Collected += EventManager.OnCollected;
        }

        protected void Collect()
        {
            Collected?.Invoke(this, EventArgs.Empty);
        }
    }
}
