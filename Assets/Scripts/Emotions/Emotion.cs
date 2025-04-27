using RedBall50.Scripts.Enums;
using UnityEngine;

namespace RedBall50.Scripts.Emotions
{
    [CreateAssetMenu(fileName = "Emotion", menuName = "Emotions")]
    public class Emotion : ScriptableObject
    {
        [field: SerializeField]
        public Sprite LeftEye { get; private set; }

        [field: SerializeField]
        public Sprite RightEye { get; private set; }

        [field: SerializeField]
        public Sprite Mouth { get; private set; }

        [field: SerializeField]
        public EmotionType EmotionType { get; private set; }
    }
}
