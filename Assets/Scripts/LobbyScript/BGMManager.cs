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
        instance = this; //�����ϰ� bgm ������Ʈ�� �ߺ� �������� �ʰ� ���� �ڵ�

      DontDestroyOnLoad(this.gameObject); //�� ������Ʈ�� ���� �Ѿ�� �ı����� �ʰ�
       

    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; //�� ��ȯ �� ȣ��Ǵ� �Լ�
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //�� ��ȯ �� ȣ�� �Ǵ� �Լ�
    {
        if(scene.name == "LobbyScene")
        {
            AudioListener.volume = 0.5f; //����� ���� ����
        }
        else if(scene.name == "StartScene")
        {
            AudioListener.volume = 1.0f;
        }

        else if(scene.name == "jhscene 1")
        {
            Destroy(this.gameObject); //���� ������ �Ѿ�� �� �� ������� ������Ʈ �ı�
        }
    }

}
