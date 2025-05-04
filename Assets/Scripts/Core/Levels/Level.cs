using System;
using RedBall50.Scripts.Managers;
using UnityEngine;

namespace RedBall50.Scripts.Core.Levels
{
    [CreateAssetMenu(
        fileName = nameof(Level), menuName = "Levels/Level")]
    public class Level : ScriptableObject
    {
        [field: SerializeField]
        public int Id { get; private set; }

        [field: SerializeField]
        public int Collectibles { get; private set; }

        [field: SerializeField]
        public int Monsters { get; private set; }

        protected int _collectedCollectibles { get; set; } = 0;
        protected int _destroyedMonsters { get; set; } = 0;

        protected event Action<object, EventArgs>? StarAchieved;

        private int _stars { get; set; } = 0;

        protected int Stars
        {
            get
            {
                var stars = CalculateStars();
                if (_stars != stars)
                {
                    _stars = stars;
                    StarAchieved?.Invoke(this, EventArgs.Empty);
                }

                return _stars;
            }
        }

        public virtual void InitializeLevel()
        {
            EventManager.Collected += OnCollected;
            EventManager.EnemyDestroyed += OnEnemyDestroyed;

            StarAchieved += EventManager.OnStarAchieved;
        }

        public virtual int CalculateStars()
        {
            var collectiblePercentage = _collectedCollectibles / Collectibles;
            var monsterPercentage = _destroyedMonsters / Monsters;
            return collectiblePercentage + monsterPercentage;
        }

        public virtual void ClaimLevel()
        {
            EventManager.Collected -= OnCollected;
            EventManager.EnemyDestroyed -= OnEnemyDestroyed;

            StarAchieved -= EventManager.OnStarAchieved;
        }

        protected virtual void OnCollected(object sender, EventArgs eventArgs)
        {
            if (++_collectedCollectibles >= Collectibles)
            {
                Debug.Log($"Current Stars : {Stars}");
            }
        }

        protected virtual void OnEnemyDestroyed(object sender, EventArgs eventArgs)
        {
            if (++_destroyedMonsters >= Monsters)
            {
                CalculateStars();
            }
        }
    }
}
