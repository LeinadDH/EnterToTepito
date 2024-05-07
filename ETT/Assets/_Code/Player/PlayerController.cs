using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private Vector2 _smoothedMoveInput;
    private Vector2 _moveInputSmoothedVelocity;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _smoothedMoveInput = Vector2.SmoothDamp(
            _smoothedMoveInput, _moveInput, ref _moveInputSmoothedVelocity, 0.1f);
        _rb.velocity = _smoothedMoveInput * _speed;
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
        
    }
}
