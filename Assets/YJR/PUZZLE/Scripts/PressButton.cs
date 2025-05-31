using UnityEngine;
using UnityEngine.Events;

public class PressButton : MonoBehaviour
{
    [Header("Button Components")]
    public Transform plate;
    public float pressDepth = 0.1f;
    public float moveSpeed = 2f;

    [Header("Trigger Settings")]
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    private int pressCount = 0;
    private Vector3 initialPosition;
    private Vector3 pressedPosition;
    private bool isPressed = false;
    private Rigidbody pressingBody;

    void Start()
    {
        Debug.Log($"[DEBUG] plate : {plate}");
        initialPosition = plate.localPosition;
        pressedPosition = initialPosition - new Vector3(0, pressDepth, 0);
    }

    void FixedUpdate()
    {
        if (pressingBody != null)
        {
            plate.localPosition = Vector3.MoveTowards(plate.localPosition, pressedPosition, Time.fixedDeltaTime * moveSpeed);

        }
        else
        {
            plate.localPosition = Vector3.MoveTowards(plate.localPosition, initialPosition, Time.fixedDeltaTime * moveSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null && pressingBody == null)
        {
            pressingBody = collision.rigidbody;
            isPressed = true;
            onPressed.Invoke();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody == pressingBody)
        {
            pressingBody = null;
            isPressed = false;
            onReleased.Invoke();
        }
    }

    public bool IsPressed() => isPressed;
}

