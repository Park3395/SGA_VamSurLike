using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unHitEvent : MonoBehaviour
{
    public GameObject ClapZone;

    public void PlayerUnHit()
    {
        ClapZone.SetActive(false);
    }
}
