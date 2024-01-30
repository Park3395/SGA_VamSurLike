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

    //// �÷��̾� �⺻ �������ͽ� 
    #region Base Staus

    // ü��
    [SerializeField] int _nowHP = 100;
    public int NowHP
    {
        get { return _nowHP; }
        set { _nowHP = value; }
    }
    // �ִ� ü��
    [SerializeField] int _maxHP = 100;
    public int MaxHP
    {
        get { return _maxHP; }
        set { _maxHP = value; }
    }
    // ��
    [SerializeField] int _barrier = 0;
    public int Barrier
    {
        get { return _barrier; }
        set { _barrier = value; }
    }
    // ü�� �ڿ� ȸ��
    [SerializeField] float _HPregen = 0;
    public float HPregen
    {
        get { return _HPregen; }
        set { _HPregen = value; }
    }



    // �÷��̾� ����
    [SerializeField] float _PLevel = 0;
    public float Plevel
    {
        get { return _PLevel; }
        set { _PLevel = value; }
    }
    // �÷��̾� ����ġ
    [SerializeField] float _Pexp = 0;
    public float Pexp
    {
        get { return _Pexp; }
        set { _Pexp = value; }
    }



    // ���ݷ�
    [SerializeField] float _dmg = 10;
    public float Dmg
    {
        get { return _dmg; }
        set { _dmg = value; }
    }
    // ���� �ӵ�
    [SerializeField] float _attSpd = 1.0f;
    public float AttSpd
    {
        get { return _attSpd; }
        set { _attSpd = value; }
    }

    // ġ��Ÿ��
    [SerializeField] float _cri = 0.1f;
    public float Cri
    {
        get { return _cri; }
        set { _cri = value; }
    }

    // ġ��Ÿ ���ط�
    [SerializeField] float _cridmg = 1.2f;
    public float Cridmg
    {
        get { return _cridmg; }
        set { _cridmg = value; }
    }


    // �̵��ӵ�
    [SerializeField] float _speed = 15.0f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    // ��������
    [SerializeField] float _jump = 0.3f;
    public float Jump
    {
        get { return _jump; }
        set { _jump = value; }
    }
    // ���� Ƚ��
    [SerializeField] int _jumpCount = 1;
    public int JumpCount
    {
        get { return _jumpCount; }
        set { _jumpCount = value; }
    }
    // �߷�
    [SerializeField] float _gravity = -1.0f;
    public float Gravity
    {
        get { return _gravity; }
        set { _gravity = value; }
    }

    #endregion

}
