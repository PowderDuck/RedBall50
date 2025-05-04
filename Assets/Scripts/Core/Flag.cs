using System;
using RedBall50.Scripts.Managers;
using UnityEngine;

namespace RedBall50.Scripts.Core
{
    public class Flag : MonoBehaviour
    {
        private void Awake()
        {
            EventManager.EventCallback(this, EventArgs.Empty);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<BallController>())
            {
                LevelManager.Instance.ClaimLevel();
            }
        }
    }
}
