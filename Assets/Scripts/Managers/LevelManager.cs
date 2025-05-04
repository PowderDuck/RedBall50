using System;
using System.Collections.Generic;
using RedBall50.Scripts.Core.Levels;
using UnityEngine;

namespace RedBall50.Scripts.Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private List<Level> _levels = default!;

        public Level CurrentLevel => _levels[_currentLevelIndex];

        private int _currentLevelIndex = 0;

        public bool Claimed { get; private set; } = false;

        public event Action<object, EventArgs>? LevelClaimed;

        private void Start()
        {
            LevelClaimed += EventManager.OnLevelClaimed;
            StartLevel(0);
        }

        public void StartLevel(int levelIndex)
        {
            if (levelIndex >= _levels.Count)
            {
                Debug.LogError(
                    $"Excessive levelIndex, MAX: [{_levels.Count - 1}, GIVEN: [{levelIndex}]]");
                return;
            }

            _currentLevelIndex = levelIndex;
            CurrentLevel.InitializeLevel();
        }

        public void ClaimLevel()
        {
            CurrentLevel.ClaimLevel();
            /*PlayerPrefs.SetInt(
                $"Level: {CurrentLevel.Id}", CurrentLevel.CalculateStars() + 1);*/
            Claimed = true;
            LevelClaimed?.Invoke(this, EventArgs.Empty);
        }
    }
}
