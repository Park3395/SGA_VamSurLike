using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    #region Animation
    // �ִϸ��̼� �̸�
    [SerializeField]
    protected string LeftClickAnim;
    [SerializeField]
    protected string ShiftAnim;
    [SerializeField]
    protected string RightClickAnim;
    [SerializeField]
    protected string EButtonAnim;
    [SerializeField]
    protected string RButtonAnim;
    [SerializeField]
    protected string QButtonAnim;
    #endregion

    #region SkillDelay
    // ��ų ��Ÿ��
    [SerializeField]
    protected float LeftSkillDelay;
    float nowLCSTime = 0f;
    [SerializeField]
    protected float ShiftSkillDelay;
    float nowSSTime = 0f;
    [SerializeField]
    protected float RightSkillDelay;
    float nowRCSTime = 0f;
    [SerializeField]
    protected float EButtonDelay;
    float nowESTime = 0f;
    [SerializeField]
    protected float RButtonDelay;
    float nowRSTime = 0f;
    [SerializeField]
    protected float QButtonDelay;
    float nowQSTime = 0f;
    #endregion

    public GameObject basicBullet;
    public Transform ShootPos;
    public Transform ShootPos_Sub;
    public Transform Body;

    public ItemBase[] onKeyItems;              // 0 : RightClick, 1 : Q, 2 : E, 3 : R

    private void Awake()
    {
        onKeyItems = new ItemBase[4];
    }

    // ��ų �̺�Ʈ ȣ�� �Լ�
    virtual protected void LeftClickSkill()
    {
        nowLCSTime = LeftSkillDelay * PlayerStat.instance.AttSpd;
    }
    virtual protected void Sft_BtnSkill()
    {
        nowSSTime = ShiftSkillDelay * PlayerStat.instance.AttSpd;
    }
    virtual protected void RightClickSkill()
    {
        if (onKeyItems[0] != null)
        {
            onKeyItems[0].itemEffect();
            RightSkillDelay = onKeyItems[0].delay;
        }

        nowRCSTime = RightSkillDelay * PlayerStat.instance.AttSpd;
    }
    virtual protected void E_BtnSkill()
    {
        if (onKeyItems[1] != null)
        {
            onKeyItems[1].itemEffect();
            EButtonDelay = onKeyItems[1].delay;
        }

        nowESTime = EButtonDelay * PlayerStat.instance.AttSpd;
    }
    virtual protected void R_BtnSkill()
    {
        if (onKeyItems[2] != null)
        {
            onKeyItems[2].itemEffect();
            RButtonDelay = onKeyItems[2].delay;
        }

        nowRSTime = RButtonDelay * PlayerStat.instance.AttSpd;
    }
    virtual protected void Q_BtnSkill()
    {
        if (onKeyItems[3] != null)
        {
            onKeyItems[3].itemEffect();
            QButtonDelay = onKeyItems[3].delay;
        }

        nowQSTime = QButtonDelay * PlayerStat.instance.AttSpd;
    }

    protected void Update()
    {
        delayReduce();

        #region BasicSkills

        // ��Ŭ�� �ѹ� ���� ��
        if (Input.GetMouseButtonDown(0) && nowLCSTime <= 0 )
        {
            LeftClickSkill();
        }

        // ��Ŭ�� ������ ���� ��
        if(Input.GetMouseButton(0))
        {
            if (nowLCSTime <= 0)
                LeftClickSkill();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && nowSSTime <= 0)
        {
            Sft_BtnSkill();
        }

        #endregion

        #region ItemSkills

        if (Input.GetMouseButtonDown (1) && nowRCSTime <= 0)
        {
            RightClickSkill();
        }
        if(Input.GetKeyDown(KeyCode.E) && nowESTime <= 0)
        {
            E_BtnSkill();
        }
        if(Input.GetKeyDown(KeyCode.R) && nowRSTime <= 0)
        {
            R_BtnSkill();
        }
        if(Input.GetKeyDown(KeyCode.Q) && nowQSTime <= 0)
        {
            Q_BtnSkill();
        }

        #endregion
    }

    void delayReduce()
    {
        if (nowLCSTime > 0)
            nowLCSTime -= Time.deltaTime;
        if (nowSSTime > 0)
            nowSSTime -= Time.deltaTime;
        if (nowRCSTime > 0)
            nowRCSTime -= Time.deltaTime;
        if (nowESTime > 0)
            nowESTime -= Time.deltaTime;
        if (nowRSTime > 0)
            nowRSTime -= Time.deltaTime;
        if (nowQSTime > 0)
            nowQSTime -= Time.deltaTime;
    }
}
