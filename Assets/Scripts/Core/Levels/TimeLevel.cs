using System;
using UnityEngine;

namespace RedBall50.Scripts.Core.Levels
{
    [CreateAssetMenu(
        fileName = nameof(TimeLevel), menuName = "Levels/Time Level")]
    public class TimeLevel : Level
    {
        [field: SerializeField]
        public float Duration { get; private set; }

        private DateTime _startTime { get; set; } = default!;

        public override void InitializeLevel()
        {
            base.InitializeLevel();

            _startTime = DateTime.Now;
        }

        public override int CalculateStars()
        {
            var collectiblePercentage = _collectedCollectibles / Collectibles;
            var monsterPercentage = _destroyedMonsters / Monsters;
            var timePercentage = _startTime <= _startTime.AddSeconds(Duration)
                ? 1 : 0;
            return Mathf.FloorToInt(
                (collectiblePercentage + monsterPercentage + timePercentage) / 3f * 2f);
        }
    }
}
