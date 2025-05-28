using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IceCube : MonoBehaviour
{
    //들어가야 하는 기능
    //IceCube에 플레이어가 쏘는 Ray가 닿으면 스크립트가 뜸 (꽤 큰 크기의 얼음 큐브. 녹일 수 있을까?)
    
    //변수
    [SerializeField] private float maxIceMelt = 100;
    [SerializeField] private float curIceMelt;

    [SerializeField] private GameObject key;
    [SerializeField] private TextMeshProUGUI script;
    
    void Start()
    {
        curIceMelt = maxIceMelt;
    }
    
    void Update()
    {
        MeltIce();
        DropKey();
    }
    
    //키보드의 f 버튼을 누르면 얼음 크기가 점점 작아지도록
    private void MeltIce()
    {
        if (Input.GetKey(KeyCode.F)) //&& 얼음을 손에 들었을 때
        {
            if(curIceMelt > 0)
            {
                script.enabled = true; //문질러 녹이기(F)라는 스크립트가 뜸
                curIceMelt--;
            }
            else
            {
                script.enabled = false;
            }
        }
        else
        {
            script.enabled = false;
        }
    }
    
    //얼음이 다 녹으면 item중 열쇠를 드랍
    private void DropKey()
    {
        if (curIceMelt <= 0)
        {
            Instantiate(key, transform.position, transform.rotation);
        }
    }
    
}
