using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoSkill : PlayerSkill
{
    Animator anim;
    CharacterController cc;
    PlayerStat pStat;
    
    [SerializeField]
    string LeftClickAnim_Sub;
    [SerializeField]
    string ShiftAnim_Sub;

    bool gunCount = false;
    float shootTime = 1.0f;
    float nowshootTime = 0f;

    Vector3 force;
    bool onAir = false;
    bool onSft = false;

    protected override void LeftClickSkill()
    {
        base.LeftClickSkill();

        if (!gunCount)
            anim.Play(LeftClickAnim);
        else
            anim.Play(LeftClickAnim_Sub);

        gunCount = !gunCount;
        nowshootTime = shootTime;
    }

    protected override void Sft_BtnSkill()
    {
        base.Sft_BtnSkill();
        if(cc.collisionFlags == CollisionFlags.Below)
        {
            anim.Play(ShiftAnim);
            onAir = false;
        }
        else
        {
            anim.Play(ShiftAnim_Sub);
            onAir = true;
        }

        onSft = true;
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        cc = GetComponent<CharacterController>();
        pStat = PlayerStat.instance;
        force = Vector3.zero;
    }

    new void Update()
    {
        base.Update();
        if (nowshootTime > 0f)
            nowshootTime -= Time.deltaTime;
        else
            gunCount = false;

        if (onSft)
            SftBtn();
    }

    void SftBtn()
    {
        if(onAir)
        {
            force.y = pStat.Jump + (pStat.Gravity * Time.deltaTime);
            
            if (cc.collisionFlags == CollisionFlags.Below)
                onSft = false;
        }
        else
        {
            if(force == Vector3.zero)
            {
                force = this.transform.forward * (pStat.Speed * 5) * Time.deltaTime;
            }

            force *= 0.98f;

            if (force.magnitude <= 0.00001f)
            {
                force = Vector3.zero;
                onSft = false;
            }
        }

        cc.Move(force);
    }
}
