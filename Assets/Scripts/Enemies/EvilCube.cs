using UnityEngine;

namespace RedBall50.Scripts.Enemies
{
    public class EvilCube : Enemy
    {
        [SerializeField] private float _rotationSpeed = 0f;
        [SerializeField] private float _movementSpeed = 0f;

        [SerializeField] private float _damageDetectionThreshold = 30f;

        private Vector3 _dynamicRotation { get; set; } = Vector3.zero;
        private Rigidbody2D _rigidbody { get; set; } = default!;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _dynamicRotation = transform.eulerAngles;
        }

        private void FixedUpdate()
        {
            _dynamicRotation += _rotationSpeed * Vector3.forward;
            // transform.eulerAngles = _dynamicRotation;
            _rigidbody.rotation = _dynamicRotation.z;
            _rigidbody.velocity = _movementSpeed * Vector3.left;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject
                    .TryGetComponent<BallController>(out var controller))
            {
                var closestPoint = collision.collider
                    .ClosestPoint(transform.position);
                var angle = Vector2.Angle(Vector2.up, closestPoint);
                if (angle <= _damageDetectionThreshold)
                {
                    _health -= 1;
                    if (_health <= 0)
                    {

                    }
                }
                else
                {
                    controller.TakeDamage(1);
                }
            }
        }
    }
}
