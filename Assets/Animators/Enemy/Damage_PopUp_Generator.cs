using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage_PopUp_Generator : MonoBehaviour
{
    public static Damage_PopUp_Generator current;
    public GameObject popUpPrefab;

    private void Awake()
    {
        current = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            CreatePopUp(Vector3.one, Random.Range(0, 1000).ToString());
        }
    }

    public void CreatePopUp(Vector3 position, string text)
    {
        var popup = Instantiate(popUpPrefab, position, Quaternion.identity);
        var temp = popup.transform.GetChild(0).GetComponent<Text>();
        temp.text = text;

        Destroy(popup, 1.0f);
    }
}
