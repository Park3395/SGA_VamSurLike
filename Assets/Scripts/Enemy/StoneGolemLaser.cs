using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGolemLaser : MonoBehaviour
{
    public Transform laserOrigin;
    public float laserRange = 50f;
    public float laserDuration = 0.05f;
    public float laserDamage = 10;

    LineRenderer laserLine;
    GameObject player;
    StoneGolemFSM fsm;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        fsm = (StoneGolemFSM)GetComponent<StoneGolemFSM>();
    }

    private void Update()
    {
        //if (fsm.skillDelay < 0.0f)
        //{

        //}
    }
}
