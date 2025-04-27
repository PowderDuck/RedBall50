using System.Collections.Generic;
using System.Linq;
using RedBall50.Scripts.Emotions;
using RedBall50.Scripts.Enums;
using UnityEngine;

namespace RedBall50.Scripts
{
    public class EmotionController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _leftEye = default!;
        [SerializeField] private SpriteRenderer _rightEye = default!;
        [SerializeField] private SpriteRenderer _mouth = default!;

        [SerializeField] private List<Emotion> _emotions = new();

        private IDictionary<EmotionType, Emotion> _emotionPairs { get; set; } = default!;
        private EmotionType _currentEmotion { get; set; } = default!;

        private void Start()
        {
            _emotionPairs = _emotions.ToDictionary(
                key => key.EmotionType,
                value => value);
        }

        public void SetEmotion(EmotionType emotionType)
        {
            _currentEmotion = emotionType;
            if (_emotionPairs.TryGetValue(_currentEmotion, out var emotion))
            {
                _leftEye.sprite = emotion.LeftEye;
                _rightEye.sprite = emotion.RightEye;
                _mouth.sprite = emotion.Mouth;
            }
        }
    }
}
