using UnityEngine;

namespace InnerDriveStudios.DruidTome
{

    /**
     * Simply a demo script to rotate this book in the Game view during play mode.
     */

    public class DragToRotate : MonoBehaviour
    {
        public float rotationSpeed = 10f;
        private Quaternion targetRotation;
        private bool isDragging = false;

        void Start()
        {
            targetRotation = transform.rotation;
        }

        void Update()
        {
            // Start drag when Alt + Left Mouse is pressed
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
            }

            // Stop drag when mouse is released
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            if (isDragging)
            {
                // Get mouse movement
                Vector3 delta = Vector3.zero;
                delta.x = Input.GetAxis("Mouse X");
                delta.y = Input.GetAxis("Mouse Y");

                float angleX = delta.x * rotationSpeed;
                float angleY = delta.y * rotationSpeed;

                // Create rotation quaternions around world axes
                Quaternion rotationX = Quaternion.AngleAxis(-angleX, Camera.main.transform.up);
                Quaternion rotationY = Quaternion.AngleAxis(angleY, Camera.main.transform.right);

                // Apply rotation
                targetRotation = rotationX * rotationY * targetRotation;
                transform.rotation = targetRotation;
            }
        }
    }

}