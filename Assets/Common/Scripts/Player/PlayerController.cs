using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rigidbody;
    private Player player; // Player 스크립트 참조

    [Header("Movement")]
    private Vector2 curMovementInput;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook = -60f;
    public float maxXLook = 60f;
    private float camCurXRot;
    public float lookSensitivity = 1.5f;

    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GetComponent<Player>(); // Player 스크립트 가져오기
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
            mouseDelta = Vector2.zero;
        }

        
        [ContextMenu("MouseLockToggle")]
        public void ToggleCursorLock()
        {
            ToggleCursor(true);
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= player.moveSpeed; // Player 스크립트의 속도 사용
        dir.y = rigidbody.velocity.y;

        rigidbody.velocity = dir;
    }

    private void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void ToggleCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}
