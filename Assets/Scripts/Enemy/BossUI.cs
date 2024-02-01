using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public Text uiHP;
    public VagrantFSM eFSM;

    private void Update()
    {
        uiHP.text = eFSM.HP.ToString() + "/" + eFSM.MaxHP.ToString();
    }
}
