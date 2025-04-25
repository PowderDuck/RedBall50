using RedBall50.Scripts.Args;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RedBall50.Scripts.UI
{
    public class InteractableUI
        : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float _activeTransparency = 0.9f;
        [SerializeField] private float _inactiveTransparency = 0.6f;

        public delegate void UpdateEvent(
            object sender, InteractableUIEventArgs eventArgs);
        public UpdateEvent? Update;

        private Image _image = default!;
        private Color _color = Color.white;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _color = _image.color;
            UpdateTransparency(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Update?.Invoke(this, new(true));
            UpdateTransparency(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Update?.Invoke(this, new(false));
            UpdateTransparency(false);
        }

        private void UpdateTransparency(bool entered)
        {
            _color.a = entered ?
                _activeTransparency : _inactiveTransparency;
            _image.color = _color;
        }
    }
}
