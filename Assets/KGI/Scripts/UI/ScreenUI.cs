using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenUI : MonoBehaviour
{
    //변수
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
    
    private void Start()
    {
        curTemperature = 35;
        if (this.gameObject.activeSelf)
        {
            isActiveScreen = true;
        }
    }

    private void Update()
    {
        ChangeTemperatureText();
        ChangeTimeText();
        
        //옵션 이동하기
        if (Input.GetKeyDown(KeyCode.W) && isActiveScreen)
        {
            MoveSelector(-1);
        }
        else if (Input.GetKeyDown(KeyCode.S) && isActiveScreen)
        {
            MoveSelector(1);
        }
        
        //옵션 선택하기
        if (Input.GetKeyDown(KeyCode.E) && isActiveScreen)
        {
            Optionselect(currentIndex);
        }
    }
    
    //시간에 따라 방 온도를 바꾸는 메서드
    private void ChangeTemperatureText()
    {
        curTemperature -= Time.deltaTime * temperatureScale;
        curTemTxt.text = $"{(int)curTemperature}도";
    }

    //시간 올리는 메서드
    private void ChangeTimeText()
    {
        curTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(curTime / 60);
        int seconds = Mathf.FloorToInt(curTime % 60);
        curTimeTxt.text = $"{minutes:00}:{seconds:00}";
    }

    private void MoveSelector(int direction)
    {
        int count = optionText.Length;
        currentIndex = (currentIndex + direction + count) % count;
        UpdateSelectorPosition();
    }
    
    private void UpdateSelectorPosition()
    {
        selector.anchoredPosition = optionText[currentIndex].anchoredPosition;
    }

    //옵션에 따라 메서드 실행
    private void Optionselect(int index)
    {
        switch (index)
        {
            case 0:
                //스크린을 초기화하는 클래스 따로 만들기
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
    
}
