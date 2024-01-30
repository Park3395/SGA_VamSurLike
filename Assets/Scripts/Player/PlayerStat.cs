using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    static PlayerStat instance = null;
    public static PlayerStat Instance()
    {
        if(instance == null)
        {
            instance = new PlayerStat();
            DontDestroyOnLoad(instance);
        }
        return instance;
    }

    //// 플레이어 기본 스테이터스 
    #region Base Staus

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



    // 플레이어 레벨
    [SerializeField] float _PLevel = 0;
    public float Plevel
    {
        get { return _PLevel; }
        set { _PLevel = value; }
    }
    // 플레이어 경험치
    [SerializeField] float _Pexp = 0;
    public float Pexp
    {
        get { return _Pexp; }
        set { _Pexp = value; }
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

    // 치명타율
    [SerializeField] float _cri = 0.1f;
    public float Cri
    {
        get { return _cri; }
        set { _cri = value; }
    }

    // 치명타 피해량
    [SerializeField] float _cridmg = 1.2f;
    public float Cridmg
    {
        get { return _cridmg; }
        set { _cridmg = value; }
    }


    // 이동속도
    [SerializeField] float _speed = 15.0f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    // 점프높이
    [SerializeField] float _jump = 0.3f;
    public float Jump
    {
        get { return _jump; }
        set { _jump = value; }
    }
    // 점프 횟수
    [SerializeField] int _jumpCount = 1;
    public int JumpCount
    {
        get { return _jumpCount; }
        set { _jumpCount = value; }
    }
    // 중력
    [SerializeField] float _gravity = -1.0f;
    public float Gravity
    {
        get { return _gravity; }
        set { _gravity = value; }
    }

    #endregion

}
