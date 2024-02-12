using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBGMManager : MonoBehaviour
{
    /*public AudioSource BgmSound;
    public AudioClip[] BgmList;
    void Update()
    {
        BgmSound = MainBGMManager.instance.bgmSound;
        BgmList = MainBGMManager.instance.bgmList;
        
    }*/
    private void OnEnable()
    {
        MainBGMManager.instance.bgmSound.Stop();
        MainBGMManager.instance.bgmSound.clip = MainBGMManager.instance.bgmList[1];
        MainBGMManager.instance.bgmSound.Play();
    }

    private void OnDisable()
    {
        MainBGMManager.instance.bgmSound.Stop();
        MainBGMManager.instance.bgmSound.clip = MainBGMManager.instance.bgmList[0];
        MainBGMManager.instance.bgmSound.Play();
    }

}
