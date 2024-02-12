using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    float dmg;
    private GameManager gameManagerInstance;
    [SerializeField]
    GameObject DamageEffect;
    [SerializeField]
    GameObject MoveEffect;

    private void Awake()
    {
        dmg = PlayerStat.instance.Dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            if(DamageEffect != null)
            {
                DamageEffect.SetActive(true);
                MoveEffect.SetActive(false);
            }

            other.gameObject.GetComponent<IHitEnemy>().HitEnemy(dmg);
            gameManagerInstance = FindObjectOfType<GameManager>();
            gameManagerInstance.totalDamage += (int)dmg;
            Destroy(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}
