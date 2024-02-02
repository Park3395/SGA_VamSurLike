using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Ready : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //OnPointer 함수들을 발동 시키기 위한 어... 뭐라해야되냐
{
    public GameObject now_difficulty;
    public Text Difficulty;
    //씬 전환
   public void OnClick()
   {
        SceneManager.LoadScene("jhscene 1");
        
   }
    //준비 아이콘 위에 마우스를 올렸을 때
    public void OnPointerEnter(PointerEventData eventData)
    {
        now_difficulty.SetActive(true);
        if (SelectNormal.instance.active_normal == true)
        {
            Difficulty.text = "현재 난이도는 보통입니다.";
        }

        if(SelectHard.instance.active_hard == true)
        {
            Difficulty.text = "현재 난이도는 어려움입니다.";
        }
        
        if(SelectEasy.instance.active_easy == true)
        {
            Difficulty.text = "현재 난이도는 쉬움입니다.";
        }
          
    }

    //준비 아이콘 위에서 마우스를 땠을 때
    public void OnPointerExit(PointerEventData eventData)
    {
        now_difficulty.SetActive(false);
    }
}
