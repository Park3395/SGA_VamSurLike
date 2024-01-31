using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TMPro�� �뵵��..TextMeshPro�� ����ϱ� ����?
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
    //���� t�� �̹����� �ؽ�Ʈ�� ������� �� �ҿ�Ǵ� �ð��� �ǹ�. Image i�� 1.5�ʵ��� õõ�� ��Ÿ���ٰ� 1.5�ʵ��� õõ�� �������
    //���� TextMeshProUGUI(Text(TMP)) j�� 1.5�ʵ��� õõ�� ������ٰ� 1.5�ʵ��� õõ�� �������.
    //�̹����� �ؽ�Ʈ�� rgb���� �״�� �ΰ� ������ �ǹ��ϴ� a�� 0-1���� �÷ȴٰ� 1-0���� �ٿ� ��Ÿ���ٰ� ������� �����ߴ�.
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
