using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _moveInput;
    private Vector2 _smoothedMoveInput;
    private Vector2 _moveInputSmoothedVelocity;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Horizontal", _moveInput.magnitude);
        _smoothedMoveInput = Vector2.SmoothDamp(
            _smoothedMoveInput, _moveInput, ref _moveInputSmoothedVelocity, 0.1f);
        _rb.velocity = _smoothedMoveInput * _speed;
        
        if(_rb.velocity.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if(_rb.velocity.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
