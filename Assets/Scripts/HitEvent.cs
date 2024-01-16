using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEvent : MonoBehaviour
{
    public BeetleFSM bfsm;

    public void PlayerHit()
    {
        bfsm.AttackAction();
    }
}
