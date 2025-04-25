using UnityEngine;

namespace RedBall50.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public abstract float MovementSpeed { get; }
    }
}
