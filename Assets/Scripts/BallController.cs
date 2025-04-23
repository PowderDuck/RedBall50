using UnityEngine;

namespace RedBall50.Scripts
{
    public class BallController : Singleton<BallController>
    {
        [SerializeField] private float _movementForce = 10f;

        private Vector2 _direction = Vector2.zero;

        private Rigidbody2D _rigidbody = default!;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _direction = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            _rigidbody.AddForce(_movementForce * _direction);
        }
    }
}
