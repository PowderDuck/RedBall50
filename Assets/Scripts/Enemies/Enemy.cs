using System;
using RedBall50.Scripts.Managers;
using UnityEngine;

namespace RedBall50.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _health = default!;

        public event Action<object, EventArgs> EnemyDestroyed;

        protected virtual void Awake()
        {
            EnemyDestroyed += EventManager.OnEnemyDestroyed;
        }

        protected void Destroyed()
        {
            EnemyDestroyed?.Invoke(this, EventArgs.Empty);
        }
    }
}
