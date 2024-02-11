using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public Slider hpSlider;
    PlayerStat playerStat;

    // Start is called before the first frame update
    void Start()
    {
        playerStat = PlayerStat.instance;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = playerStat.NowHP/playerStat.MaxHP;
    }
}
