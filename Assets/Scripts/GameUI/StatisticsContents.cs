using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsContents : MonoBehaviour
{
    public Text textAlive;
    public int aliveTime;

    private GameManager gameManagerInstance;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        //float getTime = gameManagerInstance.elapsedTime;
        //textAlive.text = getTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float getTime = gameManagerInstance.elapsedTime;
        textAlive.text = getTime.ToString();
    }
}
