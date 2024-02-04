using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LobbyAudioMixer : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MasterVol", 1.0f);    
    }

    public void SetLevel(float sliderVal)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderVal) * 20); //Log10�� �����ؾ� �ϴ� ���� ��� �ּҰ��� 0�� �ƴ϶� 0.001 log10 0 �� 1�̿���?
        PlayerPrefs.SetFloat("MasterVol", sliderVal);
    }
}
