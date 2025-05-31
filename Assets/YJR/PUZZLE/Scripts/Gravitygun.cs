using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitygun : MonoBehaviour
{
    public Transform holdPoint;
    public float grabRange = 5f;
    public float launchForce = 500f;
    public float moveSpeed = 10f;
    public float holdDistance = 3f; // 원하는 거리 추가
    public LayerMask grabLayer;

    private Rigidbody heldObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (heldObject == null)
                TryGrab();
            else
                Drop();
        }

        if (Input.GetMouseButtonDown(0) && heldObject != null)
        {
            Launch();
        }
    }
    void FixedUpdate()
         {
        if (heldObject != null)
        {
            MoveHeldObject();
        }
        }
 

    void TryGrab()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, grabRange, grabLayer))
        {
            Rigidbody rb = hit.rigidbody;
            if (rb != null)
            {
                heldObject = rb;
                heldObject.useGravity = false;
                heldObject.drag = 10f;
                heldObject.velocity = Vector3.zero;
                heldObject.angularVelocity = Vector3.zero;
            }
        }
    }

    void MoveHeldObject()
    {
        Vector3 desiredPos = Camera.main.transform.position + Camera.main.transform.forward * holdDistance;
        Vector3 direction = (desiredPos - heldObject.position);
        heldObject.velocity = direction * moveSpeed;
    }

    void Drop()
    {
        heldObject.useGravity = true;
        heldObject.drag = 0f;
        heldObject = null;
    }

    void Launch()
    {
        heldObject.useGravity = true;
        heldObject.drag = 0f;
        heldObject.AddForce(Camera.main.transform.forward * launchForce, ForceMode.Impulse);
        heldObject = null;
    }
}
