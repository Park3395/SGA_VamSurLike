using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBGMManager : MonoBehaviour
{
    private static MainBGMManager instance; //ΩÃ±€≈Ê ∆–≈œ
    public AudioSource bgmSound;
    public AudioClip[] bgmList;
    public GameObject boss;

    void Awake()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");


        if (instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Update()
    {
        if (boss.gameObject.activeSelf == false)
        {
            bgmSound.clip = bgmList[0];
            bgmSound.Play();
        }

        else if (boss.gameObject.activeSelf == true)
        {
            bgmSound.clip = bgmList[1];
            bgmSound.Play();
        }

        
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Start")
        {
            Destroy(this.gameObject);
        }
    }
}
