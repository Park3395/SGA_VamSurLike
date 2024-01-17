using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoSkill : PlayerSkill
{
    Animator anim;
    
    [SerializeField]
    string LeftClickAnim_Sub;

    bool gunCount = false;

    float shootTime = 1.0f;
    float nowshootTime = 0f;

    protected override void LeftClickSkill()
    {
        Debug.Log("Shoot");

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
        anim.Play(ShiftAnim);

    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    new void Update()
    {
        base.Update();
        if (nowshootTime > 0f)
            nowshootTime -= Time.deltaTime;
        else
            gunCount = false;
    }
}
