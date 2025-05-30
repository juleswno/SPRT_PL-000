using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{

    //���� ����
    //�ҷ�����
    //����
    //���� ����

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
        //���� ������ ������ ��
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
