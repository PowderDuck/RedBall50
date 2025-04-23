using UnityEngine;

namespace RedBall50.Scripts
{
    public abstract class Singleton<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            Instance = GetComponent<T>();
        }
    }
}