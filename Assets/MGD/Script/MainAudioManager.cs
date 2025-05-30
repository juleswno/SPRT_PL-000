using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainAudioManager : MonoBehaviour
{
    public static MainAudioManager Instance;

    [Header("BGM & SFX")]
    public AudioSource bgmaduioSource;
    public AudioSource sfxaduioSource;

    public Slider bgmSlider;
    public Slider sfxSlider;

    [SerializeField]
    private GameObject SettingPannel;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void MusicVoulme()
    {

        bgmaduioSource.volume = bgmSlider.value;
        sfxaduioSource.volume = sfxSlider.value;
    }

    //ȿ���� ȣ���Ҷ� �Լ� ȣ��
    //MainAudioManager.Instance.PlaySfx()
    //�� �繰���� ����� Ŭ��
    public void PlaySfx(AudioClip clip)
    {
        sfxaduioSource.clip = clip;
        sfxaduioSource.Play();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MusicVoulme();
    }
}
