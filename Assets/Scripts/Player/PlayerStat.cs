using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
//// �÷��̾� �⺻ �������ͽ� 
#region Status Base

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

    // �̵��ӵ�
    [SerializeField] float _speed = 5.0f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    // ��������
    [SerializeField] float _jump = 8.0f;
    public float Jump
    {
        get { return _jump; }
        set { _jump = value; }
    }
    // �߷�
    [SerializeField]float _gravity = -20.0f;
    public float Gravity
    {
        get { return _gravity; }
        set { _gravity = value; }
    }

#endregion
}
