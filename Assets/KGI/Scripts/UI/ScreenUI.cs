using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum SelectNumber
{
    Box1,
    Box2,
    Box3,
    Box4
}

public class ScreenUI : MonoBehaviour
{
    //스크린에서 e를 눌러서 선택하고
    //W와 S를 이용해서 움직이기
    
    //변수
    public TextMeshProUGUI curTemTxt;
    public TextMeshProUGUI curTimeTxt;
    public List<SelectNumber> selectNumbers = new List<SelectNumber>();
    
    [SerializeField] private float temperatureScale = 0.2f;
    private float curTemperature;
    private float curTime;
    private float maxTime;
    
    private void Start()
    {
        curTemperature = 35;
    }

    private void Update()
    {
        ChangeTemperatureText();
        ChangeTimeText();
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
        curTimeTxt.text = $"{curTime}";
    }

    private void SelectBox()
    {
        if (Input.GetKey(KeyCode.E))
        {
            
        }
    }
    
}
