using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeinUI : MonoBehaviour
{
    //E Ȱ��ȭ ��Ȱ��ȭ
    //���� ����
    //����â
    //������ > title ȭ������ �̵�
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
        //Ȱ��ȭ , ��Ȱ��ȭ
        IsMainOpen = !IsMainOpen;
        MainPannel.SetActive(IsMainOpen);

        if(IsMainOpen)
            Time.timeScale = 0; //���� ����
        else
            Time.timeScale = 1; //���� ����
    }

    public void TitleMove()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
