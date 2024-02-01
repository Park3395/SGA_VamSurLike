using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TMPro의 용도가..TextMeshPro를 사용하기 위해?
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField] Image image = null;
    [SerializeField] TextMeshProUGUI text = null;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeTextToFullAlpha(1.5f, image, text));
    }

    void Update()
    {

    }
    //변수 t는 이미지나 텍스트가 사라지는 데 소요되는 시간을 의미. Image i가 1.5초동안 천천히 나타났다가 1.5초동안 천천히 사라지고
    //이후 TextMeshProUGUI(Text(TMP)) j가 1.5초동안 천천히 사라졌다가 1.5초동안 천천히 사라진다.
    //이미지나 텍스트의 rgb값은 그대로 두고 투명도를 의미하는 a를 0-1까지 올렸다가 1-0으로 줄여 나타났다가 사라진걸 구현했다.
    public IEnumerator FadeTextToFullAlpha(float t, Image i, TextMeshProUGUI j)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        j.color = new Color(j.color.r, j.color.g, j.color.b, 0);

        while(i.color.a <1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while(i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }

        while(j.color.a < 1.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a + (Time.deltaTime / t));
            yield return null;
        }
        j.color = new Color(j.color.r, j.color.g, j.color.b, 1);
        while(j.color.a > 0.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a - (Time.deltaTime / t));
            yield return null;
        }

        SceneManager.LoadScene("StartScene");
    }

}
