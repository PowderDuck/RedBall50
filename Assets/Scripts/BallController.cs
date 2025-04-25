using RedBall50.Scripts.Args;
using RedBall50.Scripts.UI;
using UnityEngine;

namespace RedBall50.Scripts
{
    public class BallController : Singleton<BallController>
    {
        [SerializeField] private InteractableUI _leftMoveBtn = default!;
        [SerializeField] private InteractableUI _rightMoveBtn = default!;
        [SerializeField] private InteractableUI _jumpBtn = default!;

        [SerializeField] private float _movementForce = 10f;
        [SerializeField] private float _jumpForce = 10f;

        [SerializeField] private float _jumpDetectionThreshold = 30f;

        private Vector2 _direction = Vector2.zero;

        private Rigidbody2D _rigidbody = default!;

        private bool _isGrounded = false;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _leftMoveBtn.Update += (sender, eventArgs) =>
                OnMovementPressed(eventArgs, Vector2.left);
            _rightMoveBtn.Update += (sender, eventArgs)
                => OnMovementPressed(eventArgs, Vector2.right);
            _jumpBtn.Update += OnJump;
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_movementForce * _direction);
        }

        private void OnMovementPressed(
            InteractableUIEventArgs eventArgs,
            Vector2 direction)
        {
            _direction += eventArgs.Entered ? direction : -direction;
        }

        private void OnJump(
            object sender, InteractableUIEventArgs eventArgs)
        {
            if (eventArgs.Entered && _isGrounded)
            {
                _rigidbody.AddForce(_jumpForce * Vector2.up);
                _isGrounded = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var closestPoint = collision.collider
                .ClosestPoint(transform.position);

            if (!_isGrounded)
            {
                var direction = closestPoint - new Vector2(transform.position.x, transform.position.y);
                _isGrounded = Vector2.Angle(Vector2.down, direction) <= _jumpDetectionThreshold;
            }
        }
    }
}
