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
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderVal) * 20); //Log10을 대입해야 하는 것을 기억 최소값은 0이 아니라 0.001 log10 0 은 1이였나?
        PlayerPrefs.SetFloat("MasterVol", sliderVal);
    }
}
