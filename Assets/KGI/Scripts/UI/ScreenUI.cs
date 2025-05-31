using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenUI : MonoBehaviour
{
    //변수
    public InitScreen initScreen;
    public CubeObject cubeObject;
    public TextMeshProUGUI curTemTxt;
    public TextMeshProUGUI curTimeTxt;
    
    [Header("선택 인디케이터")]
    public RectTransform selector;
    [Header("옵션 텍스트")]
    public RectTransform[] optionText;
    
    [SerializeField] private float temperatureScale = 0.2f;
    private float curTemperature;
    private float curTime;
    private float maxTime;

    private int currentIndex = 0;
    private bool isActiveScreen;
    private int curdirectionIndex;
    
    private void Start()
    {
        curTemperature = 30;
    }
    
    private void Update()
    {
        //화면 켜졌는지 여부 검사하기
        if (this.gameObject.activeSelf)
        {
            isActiveScreen = true;
        }
        else
        {
            isActiveScreen = false;
        }
        
        ChangeTemperatureText();
        ChangeTimeText();
        
        //옵션 이동하기
        if (Input.GetKeyDown(KeyCode.W) && isActiveScreen)
        {
            MoveSelector(-1);
        }
        else if (Input.GetKeyDown(KeyCode.S) && isActiveScreen)
        {
            MoveSelector(+1);
        }
        
        //옵션 선택하기
        if (Input.GetKeyDown(KeyCode.E) && isActiveScreen)
        {
            Optionselect(currentIndex);
        }
        
        //종료하기
        if (Input.GetKeyDown(KeyCode.Escape) && isActiveScreen)
        {
            cubeObject.OffScreen();
            initScreen.InitDiscription(curdirectionIndex);
        }
    }
    
    //시간에 따라 방 온도를 바꾸는 메서드
    private void ChangeTemperatureText()
    {
        curTemperature -= Time.deltaTime * temperatureScale;
        curTemTxt.text = $"{(int)curTemperature}도";
        
        if (curTemperature < -40)
        {
            Debug.Log("죽었다!");
            //게임 오버 코드 불러오기
        }
    }

    //시간 올리는 메서드
    private void ChangeTimeText()
    {
        curTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(curTime / 60);
        int seconds = Mathf.FloorToInt(curTime % 60);
        curTimeTxt.text = $"{minutes:00}:{seconds:00}";
    }

    //selectBox의 위치 조정
    private void MoveSelector(int direction)
    {
        //간격 구하기
        // float stepY = Mathf.Abs(optionText[1].anchoredPosition.y - optionText[0].anchoredPosition.y);
        // selector.anchoredPosition += new Vector2(0, -stepY * direction);
        
        currentIndex = Mathf.Clamp(currentIndex + direction, 0, optionText.Length -1);
        selector.anchoredPosition = optionText[currentIndex].anchoredPosition;
    }

    //옵션에 따라 메서드 실행
    private void Optionselect(int index)
    {
        switch (index)
        {
            case 0:
                initScreen.SelectDiscription(1);
                curdirectionIndex = 1;
                break;
            case 1:
                initScreen.SelectDiscription(4);
                curdirectionIndex = 4;
                break;
            case 2:
                break;
        }
    }
}
