using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScreen : MonoBehaviour
{
    //스크린 초기화 -> 다음 스크린으로 넘어감
    
    [SerializeField] private GameObject[] discription;
    
    public void InitDiscription(int directionIndex)
    {
        discription[directionIndex-1].SetActive(false);
        discription[directionIndex].SetActive(true);
    }
}
