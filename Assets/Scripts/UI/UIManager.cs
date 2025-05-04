using System;
using UnityEngine;

namespace RedBall50.Scripts.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject _starUIPrefab = default!;

        private Canvas _canvas { get; set; } = default!;

        private void Start()
        {
            _canvas = GetComponent<Canvas>();

            EventManager.StarAchieved += OnStarAchieved;
        }

        private void OnStarAchieved(object sender, EventArgs eventArgs)
        {
            var star = Instantiate(_starUIPrefab, _canvas.transform);
            star.transform.localPosition = Vector3.zero;
            // TODO: DOTWEEN;
        }
    }
}
