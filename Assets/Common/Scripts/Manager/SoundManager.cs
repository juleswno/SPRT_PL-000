using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum EAudioMixerType
{
    Master,
    Bgm,
    SFX
}
public class SoundManager : MonoBehaviour
{
    //싱글톤으로 만들어서 어떤 오브젝트든 붙여서 효과음을 낼 수 있게
    public static SoundManager Instance {get; private set;}
    [SerializeField] private AudioMixer audioMixer;
    
    private bool[] _isMuteAudio = new bool[3];
    private float[] audioVolumes = new float[3];
    private bool[] _isLoopAudio = new bool[3];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //오디오 볼륨 조절
    public void ControlVolume(EAudioMixerType audioMixerType, float value)
    {
        audioMixer.SetFloat(audioMixerType.ToString(), Mathf.Log10(value));
    }
    
    //오디오 뮤트 여부
    public void MuteVolume(EAudioMixerType audioMixerType)
    {
        int type = (int)audioMixerType;
        if (!_isMuteAudio[type])
        {
            _isMuteAudio[type] = true;
            audioMixer.GetFloat(audioMixerType.ToString(), out float curVolume);
            audioVolumes[type] = curVolume;
            ControlVolume(audioMixerType, 0.001f);
        }
        else
        {
            _isMuteAudio[type] = false;
            ControlVolume(audioMixerType, audioVolumes[type]);
        }
    }
    
    //슬라이더 스크립트는 따로 만들어서 붙이기
}
