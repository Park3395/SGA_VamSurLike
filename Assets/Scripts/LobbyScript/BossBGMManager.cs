using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBGMManager : MonoBehaviour
{
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
