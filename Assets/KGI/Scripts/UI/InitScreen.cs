using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScreen : MonoBehaviour
{
    //스크린 초기화 -> 다음 스크린으로 넘어감
    
    [SerializeField] private GameObject[] discription;
    
    //discription 선택하기
    public void SelectDiscription(int directionIndex)
    {
        discription[directionIndex-1].SetActive(false);
        discription[directionIndex].SetActive(true);
    }

    //종료할 때 스크린 초기화
    public void InitDiscription(int curdirectionIndex)
    {
        discription[curdirectionIndex].SetActive(false);
        discription[0].SetActive(true);
    }
    
}
