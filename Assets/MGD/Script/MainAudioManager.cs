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

    //효과음 호출할때 함수 호출
    //MainAudioManager.Instance.PlaySfx()
    //각 사물마다 오디오 클립
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
