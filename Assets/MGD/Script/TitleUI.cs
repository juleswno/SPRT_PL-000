using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{

    //게임 시작
    //불러오기
    //설정
    //게임 종료

    [SerializeField]
    private GameObject settingPannel;
    [SerializeField]
    private GameObject TitlePannel;
    [SerializeField]
    private AudioSource titleAudio;
    [SerializeField]
    private AudioClip BackGroundMusic;
    [SerializeField]
    private Slider volumeSlider;


    public void GameStart()
    {
        SceneManager.LoadScene("UI");
    }

    public void GameLoad()
    {
        //저장 데이터 구현된 후
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (settingPannel.activeSelf)
            titleAudio.volume = volumeSlider.value;
    }

    public void GameSettingBtn()
    {
        settingPannel.SetActive(true);
        TitlePannel.SetActive(false);
    }

    public void SettingExit()
    {
        settingPannel.SetActive(false);
        TitlePannel.SetActive(true);
    }

}
