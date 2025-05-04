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

        private float _side { get; set; } = 1f;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _dynamicRotation = transform.eulerAngles;
        }

        private void FixedUpdate()
        {
            _dynamicRotation += _rotationSpeed * _side * Vector3.forward;
            transform.eulerAngles = _dynamicRotation;

            _rigidbody.velocity = _movementSpeed * _side * Vector3.left;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject
                    .TryGetComponent<BallController>(out var controller))
            {
                var angle = CollisionAngle(
                    collision, transform.position, Vector2.up);
                if (angle <= _damageDetectionThreshold)
                {
                    _health -= 1;
                    if (_health <= 0)
                    {
                        Destroyed();
                        Destroy(gameObject);
                    }
                }
                else
                {
                    controller.TakeDamage(1);
                }
            }
            else
            {
                if (CollisionAngle(collision, transform.position, Vector2.up)
                    is >= 45f and < 95f)
                {
                    _side *= -1f;
                }
            }
        }

        private static float CollisionAngle(
            Collision2D collision,
            Vector3 referencePosition,
            Vector3 direction)
        {
            return Vector2.Angle(
                direction,
                collision.collider
                    .ClosestPoint(referencePosition) - (Vector2)referencePosition);
        }
    }
}
