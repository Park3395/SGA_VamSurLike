using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
//// 플레이어 기본 스테이터스 
#region Status Base

    // 체력
    [SerializeField] int _nowHP = 100;
    public int NowHP
    {
        get { return _nowHP; }
        set { _nowHP = value; } 
    }
    // 최대 체력
    [SerializeField] int _maxHP = 100;
    public int MaxHP
    {
        get { return _maxHP; }
        set { _maxHP = value; }
    }
    // 방어막
    [SerializeField] int _barrier = 0;
    public int Barrier
    {
        get { return _barrier; }
        set { _barrier = value; }
    }
    // 체력 자연 회복
    [SerializeField] float _HPregen = 0;
    public float HPregen
    {
        get { return _HPregen; }
        set { _HPregen = value; }
    }

    // 공격력
    [SerializeField] float _dmg = 10;
    public float Dmg
    {
        get { return _dmg; }
        set { _dmg = value; }
    }
    // 공격 속도
    [SerializeField] float _attSpd = 1.0f;
    public float AttSpd
    {
        get { return _attSpd; }
        set { _attSpd = value; }
    }

    // 이동속도
    [SerializeField] float _speed = 5.0f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    // 점프높이
    [SerializeField] float _jump = 8.0f;
    public float Jump
    {
        get { return _jump; }
        set { _jump = value; }
    }
    // 중력
    [SerializeField]float _gravity = -20.0f;
    public float Gravity
    {
        get { return _gravity; }
        set { _gravity = value; }
    }

#endregion
}
