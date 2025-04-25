using RedBall50.Scripts.Enums;
using UnityEngine;

namespace RedBall50.Scripts
{
    public class EmotionController : MonoBehaviour
    {
        [SerializeField] private GameObject _leftEye = default!;
        [SerializeField] private GameObject _rightEye = default!;
        [SerializeField] private GameObject _mouth = default!;

        private Emotion _currentEmotion { get; set; } = default!;
    }
}
