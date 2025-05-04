using UnityEngine;

namespace RedBall50.Scripts.Collectibles
{
    public class Coin : Collectible
    {
        [SerializeField] private float _fadeExtension = 1.2f;
        [SerializeField] private float _fadeDuration = 0.75f;

        private float _currentFadeTime { get; set; } = 0f;
        private SpriteRenderer _renderer { get; set; } = default!;

        private bool IsFading => _currentFadeTime > 0;

        private Vector3 _initialScale = Vector3.one;
        private Color _initialColor = Color.white;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _initialColor = _renderer.color;
            _initialScale = transform.localScale;
        }

        private void Update()
        {
            if (IsFading)
            {
                _currentFadeTime = Mathf.Max(
                    0, _currentFadeTime - Time.deltaTime);

                var percentage = _currentFadeTime / _fadeDuration;
                _initialColor.a = percentage;
                _renderer.color = _initialColor;
                transform.localScale =
                    Vector3.Lerp(_initialScale, _initialScale * _fadeExtension, 1f - percentage);

                if (!IsFading)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<BallController>())
            {
                Collect();
                if (_currentFadeTime <= 0)
                {
                    _currentFadeTime = _fadeDuration;
                }
            }
        }
    }
}
