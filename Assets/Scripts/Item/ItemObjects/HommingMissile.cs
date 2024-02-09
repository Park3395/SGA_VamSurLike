using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HommingMissile : MonoBehaviour
{
    Vector3 force;
    float speed = 180f;
    float nowt = 0f;
    float maxt = 2f;
    PlayerStat stat;
    float dmg;

    private GameManager gameManagerInstance;


    GameObject Target;

    private void Awake()
    {
        //    stat = PlayerStat.instance;
        //    dmg = stat.Dmg;

        //    #region shootforce

        //    RaycastHit hit;
        //    Transform cam = Camera.main.transform;

        //    Ray ray = new Ray(cam.position, cam.forward);
        //    Vector3 endpoint = ray.origin + (ray.direction * 50f);

        //    Physics.Raycast(ray, out hit, 50f);

        //    if (hit.point != Vector3.zero)
        //    {
        //        force = hit.point - this.transform.position;
        //    }
        //    else
        //    {
        //        force = endpoint - this.transform.position;
        //    }
        //    force.Normalize();

        Target = GameObject.FindWithTag("Enemy");
    }

    private void Update()
    {
        this.transform.Translate(Vector3.Lerp(this.transform.position, Target.transform.position, speed));
    }

    private void OnTriggerEnter(Collider other)
    {
        this.transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;

        //    if (other.gameObject.layer == 9)
        //    {
        //        other.gameObject.GetComponent<IHitEnemy>().HitEnemy(dmg);
        //        gameManagerInstance = FindObjectOfType<GameManager>();
        //        gameManagerInstance.totalDamage += (int)dmg;
        //        // 데미지 팝업 띄울 위치 변경중.
        //        Damage_PopUp_Generator.current.CreatePopUp(other.gameObject.transform.position, dmg.ToString());
        //        Destroy(this.gameObject);
        //    }
        //    else
        //        Destroy(this.gameObject);

        Destroy(this.gameObject);
    }
}
