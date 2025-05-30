using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeinUI : MonoBehaviour
{
    //E 활성화 비활성화
    //게임 정지
    //설정창
    //나가기 > title 화면으로 이동
    [SerializeField]
    private GameObject MainPannel;
    [SerializeField]
    private bool IsMainOpen = false;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MainUIOpen();
    }

    private void MainUIOpen()
    {
        //활성화 , 비활성화
        IsMainOpen = !IsMainOpen;
        MainPannel.SetActive(IsMainOpen);

        if(IsMainOpen)
            Time.timeScale = 0; //게임 정지
        else
            Time.timeScale = 1; //게임 시작
    }

    public void TitleMove()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
