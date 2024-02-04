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
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderVal) * 20); //Log10을 대입해야 하는 것을 기억
        PlayerPrefs.SetFloat("MasterVol", sliderVal);
    }
}
