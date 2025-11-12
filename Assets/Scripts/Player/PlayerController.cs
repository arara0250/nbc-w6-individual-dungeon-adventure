using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float moveSpeed;
    private Vector2 curMovementInput;
    private bool isMoving;

    [Header("Jump")]
    [SerializeField] private float jumpPower;
    public LayerMask groundLayerMask;

    [Header("Look")]
    [SerializeField] Transform cameraContainer;
    [SerializeField] private float minXLook;
    [SerializeField] private float maxXLook;
    [SerializeField] private float lookSensitivity;
    private float camCurXRot;
    private Vector2 mouseDelta;

    [Header("Interaction")]
    [SerializeField] private float checkRate = 0.05f;
    private float lastCheckTime;
    [SerializeField] private float maxRayDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject curInteractGameObject;
    [SerializeField] private TextMeshProUGUI interactionText;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        GameManager.Instance.PlayerManager.controller = this;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        TryInteraction();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
            isMoving = true;
            _animator.SetBool("IsMoving", isMoving);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            isMoving = false;
            _animator.SetBool("IsMoving", isMoving);
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
        if (context.phase == InputActionPhase.Started && isOnGround())
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
            _animator.SetTrigger("Jump");
        }
    }

    bool isOnGround()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
                return true;
        }

        return false;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();

        float lookingThreshold = 0.5f;

        if (mouseDelta.magnitude > lookingThreshold || isMoving)
            _animator.SetBool("IsMoving", true);
        else
            _animator.SetBool("IsMoving", false);
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _animator.SetTrigger("Interact");
        }
    }

    void TryInteraction()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, transform.forward * maxRayDistance, Color.red);

            if (Physics.Raycast(ray, out hit, maxRayDistance, layerMask))
            {
                curInteractGameObject = hit.collider.gameObject;

                interactionText.gameObject.SetActive(true);
                interactionText.text = "Open";
            }
        }
    }
}
