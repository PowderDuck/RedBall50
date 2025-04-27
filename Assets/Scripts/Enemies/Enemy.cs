using UnityEngine;

namespace RedBall50.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _health = default!;
    }
}
