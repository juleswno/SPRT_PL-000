using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform leftdoor;
    public Transform rightdoor;

    public float slideDistance = 1.5f;
    public float slideSpeed = 2f;

    private Vector3 leftClosedPos;
    private Vector3 rightClosedPos;
    private Vector3 leftOpenPos;
    private Vector3 rightOpenPos;

    private bool isOpen = false;
    

    void Start()
    {
        leftClosedPos = leftdoor.localPosition;
        rightClosedPos = rightdoor.localPosition;

        leftOpenPos = leftClosedPos + Vector3.left * slideDistance;
        rightOpenPos = rightClosedPos + Vector3.right * slideDistance; 

    }

    void Update( )
    {
        leftdoor.localPosition = Vector3.Lerp(
            leftdoor.localPosition,
            isOpen ? leftOpenPos : leftClosedPos,
            Time.deltaTime * slideSpeed
            );

        rightdoor.localPosition = Vector3.Lerp(
            rightdoor.localPosition,
            isOpen ? rightOpenPos : rightClosedPos,
            Time.deltaTime * slideSpeed
            );
    }

    public void Open() => isOpen = true;
    public void Close() => isOpen = false; 
}
