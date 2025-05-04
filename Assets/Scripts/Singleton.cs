using UnityEngine;

namespace RedBall50.Scripts
{
    public abstract class Singleton<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            Instance = Instance == null ?
                GetComponent<T>() : throw new System.Exception(
                    $"Only one Instance of {typeof(T).Name} is Allowed");

            DontDestroyOnLoad(this);
        }
    }
}