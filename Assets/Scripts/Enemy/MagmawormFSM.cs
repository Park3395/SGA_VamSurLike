using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmawormFSM : MonoBehaviour
{
    // MagmaWorm ���� //
    // ü��
    public int HP = 2400;
    // �ִ� ü��
    public int MaxHP = 2400;
    // ���ݷ�
    public int attackPower = 10;
    // �̵� �ӵ�
    public float speed = 20f;
    // ���� ���� ������ ���� ����
    public float diameter = 30f;
    // ���� ����
    public float jumpHeight = 100f;
    // ���� ���� ��ġ
    private Vector3 playerStartPosition;
    private bool isJumping = false;

    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Jump();
    }

    private void Update()
    {
        if (!isJumping)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Debug.Log("Jump");

        // Set player's start position when the jump begins
        playerStartPosition = player.position;

        // Start jumping coroutine
        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        isJumping = true;

        // Calculate random coordinates within a circle
        Vector3 circleCenter = new Vector3(playerStartPosition.x, 0f, playerStartPosition.z);
        Vector3 randomPos = Random.insideUnitCircle.normalized * diameter / 2f;
        Vector3 jumpStartPos = circleCenter + new Vector3(randomPos.x, 0f, randomPos.y);

        // Jump up to the specified height
        float startTime = Time.time;
        while (transform.position.y < jumpHeight)
        {
            float t = (Time.time - startTime) * speed;
            transform.position = Parabola(jumpStartPos, new Vector3(jumpStartPos.x, jumpHeight, jumpStartPos.z), t);
            yield return null;
        }

        // Attack by falling along a parabola towards the player's position
        startTime = Time.time;
        while (transform.position.y > playerStartPosition.y)
        {
            float t = (Time.time - startTime) * speed;
            transform.position = Parabola(new Vector3(jumpStartPos.x, jumpHeight, jumpStartPos.z), playerStartPosition, t);
            yield return null;
        }

        // Check if the player is hit and inflict damage
        if (CheckCollision(player.position, transform.position))
        {
            Debug.Log("Magma Worm collides with the player, inflicting damage!");
            InflictDamage();
        }

        // Reset the jumping state
        isJumping = false;
    }

    private Vector3 Parabola(Vector3 start, Vector3 end, float t)
    {
        return Vector3.Lerp(start, end, t) + Vector3.up * (-4f * (end.y - start.y) * t * t + 4f * (end.y - start.y) * t);
    }

    private void InflictDamage()
    {
        // You can implement your damage logic here
        // For example: PlayerController.Instance.TakeDamage(attackPower);
    }

    private bool CheckCollision(Vector3 playerPosition, Vector3 wormPosition)
    {
        // Simple collision check (for demonstration purposes)
        float distance = Vector3.Distance(playerPosition, wormPosition);
        return distance < 5f; // Assuming collision if distance is less than 5 meters
    }
}
