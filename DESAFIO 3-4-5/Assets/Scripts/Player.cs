using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private PlayerAnimation _anim;
    [SerializeField]
    private float moveSpeed = 4f;
    [SerializeField]
    private float jumpForce = 2f;

    private PlayerInputActions _playerControls;
    private Vector2 _moveDirection = Vector2.zero;

    private void Awake()
    {
        _playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _playerControls.Player.Enable();

        _playerControls.Player.Attack.performed += Attack;
        _playerControls.Player.Jump.performed += Jump;
    }

    private void OnDisable()
    {
        _playerControls.Player.Disable();
    }

    private void FixedUpdate()
    {
        _moveDirection = _playerControls.Player.Move.ReadValue<Vector2>();

        if (IsGrounded())
        {
            _anim.Jump(false);
        }

        if (_moveDirection != Vector2.zero)
        {
            _anim.Move(true);
        }
        else
        {
            _anim.Move(false);
        }

        Move();
    }

    private void Move()
    {
        if (_moveDirection.x == 0)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            return;
        }

        else if (_moveDirection.x < 0)
        {
            _rb.velocity = new Vector2(-moveSpeed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);
        }

        Flip();
    }

    private void Flip(){
        _spriteRenderer.flipX = _moveDirection.x < 0;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        _anim.Attack();
    }

    private bool IsGrounded()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        if (hitInfo.collider != null)
        {
            _anim.Jump(false);
            return true;
        }
        return false;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _anim.Jump(true);
        }
    }
}




