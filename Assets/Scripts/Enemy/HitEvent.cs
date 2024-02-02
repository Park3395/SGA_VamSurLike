using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEvent : MonoBehaviour
{
    public GameObject ClapZone;

    public void PlayerHit()
    {
        ClapZone.SetActive(true);
    }
}
