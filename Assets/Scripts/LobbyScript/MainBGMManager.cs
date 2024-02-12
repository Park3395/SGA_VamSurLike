using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BGMType { stage = 0, Boss }

public class MainBGMManager : MonoBehaviour
{
    public static MainBGMManager instance; //ΩÃ±€≈Ê ∆–≈œ
    [SerializeField]
    public AudioClip[] bgmList;
    public AudioSource bgmSound;
   

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Start")
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangetoBossBGM(BGMType index)
    {
        bgmSound.Stop();
        bgmSound.clip = bgmList[1];
        bgmSound.Play();
    }





}
