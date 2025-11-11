using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float moveSpeed;
    private Vector2 curMovementInput;

    [Header("Jump")]
    [SerializeField] private float jumpPower;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        GameManager.Instance.PlayerManager.controller = this;

        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
            _animator.SetBool("IsMoving", true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            _animator.SetBool("IsMoving", false);
        }
    }

    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
            _animator.SetTrigger("Jump");
        }
    }
}
