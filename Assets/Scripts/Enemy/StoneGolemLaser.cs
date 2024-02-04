using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGolemLaser : MonoBehaviour
{
    public float aimDuration = 3f;
    public float fireDuration = 0.5f;
    public float cooldownDuration = 10f;
    public float laserDamage = 10f;
    public GameObject laserPrefab;

    private Transform player;
    private bool isCoolingDown = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isCoolingDown && !IsObstacleBetweenMonsterAndPlayer())
        {
            StartCoroutine(AimAndFire());
        }
    }

    bool IsObstacleBetweenMonsterAndPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (player.position - transform.position).normalized, out hit, Vector3.Distance(transform.position, player.position)))
        {
            return !hit.collider.CompareTag("Player");
        }
        return false;
    }

    IEnumerator AimAndFire()
    {
        isCoolingDown = true;

        // Aim at player for aimDuration seconds
        transform.LookAt(player);
        yield return new WaitForSeconds(aimDuration);

        // Check for obstacles between monster and player
        if (!IsObstacleBetweenMonsterAndPlayer())
        {
            // Instantiate the laser prefab at the current position
            GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation);

            // Wait for fireDuration seconds
            yield return new WaitForSeconds(fireDuration);

            // Destroy the laser after fireDuration seconds
            Destroy(laser);

            // Reset cooldown
            yield return new WaitForSeconds(cooldownDuration);
        }

        isCoolingDown = false;
    }
}
