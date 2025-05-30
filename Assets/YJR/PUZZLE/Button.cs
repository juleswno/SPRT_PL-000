using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
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

    void Start()
    {
        initialPosition = plate.localPosition;
        pressedPosition = initialPosition - new Vector3(0, pressDepth, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[PRESSURE BUTTON] Trigger Enter: {other.name}");
        if (other.attachedRigidbody != null)
        {
            pressCount++;
            if (!isPressed)
            {
                isPressed = true;
                onPressed.Invoke();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            pressCount--;
            if (pressCount <= 0)
            {
                pressCount = 0;
                isPressed = false;
                onReleased.Invoke();
            }
        }
    }

    void Update()
    {
        Vector3 targetPos = isPressed ? pressedPosition : initialPosition;
        plate.localPosition = Vector3.Lerp(plate.localPosition, targetPos, Time.deltaTime * moveSpeed);
    }
}

