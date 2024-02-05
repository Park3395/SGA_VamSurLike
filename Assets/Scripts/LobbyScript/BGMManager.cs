using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this; //간단하게 bgm 오브젝트가 중복 생성되지 않게 막는 코드

      DontDestroyOnLoad(this.gameObject); //이 오브젝트를 씬이 넘어가도 파괴하지 않게
       

    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; //씬 전환 시 호출되는 함수
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //씬 전환 시 호출 되는 함수
    {
        if(scene.name == "LobbyScene")
        {
            AudioListener.volume = 0.5f; //오디오 볼륨 조절
        }
        else if(scene.name == "StartScene")
        {
            AudioListener.volume = 1.0f;
        }

        else if(scene.name == "jhscene 1")
        {
            Destroy(this.gameObject); //메인 씬으로 넘어갔을 때 이 배경음악 오브젝트 파괴
        }
    }

}
