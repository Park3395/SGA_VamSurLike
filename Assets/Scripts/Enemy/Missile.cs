using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float gravity = 9.8f;

    private Vector3 initialPosition;
    private float timeElapsed = 0f;

    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPosition = transform.position;

        // Launch the projectile
        Launch();
    }

    private void Update()
    {
        // Update the position based on the parabolic trajectory
        UpdatePosition();
    }

    private void Launch()
    {
        // Calculate the initial velocity required for the desired trajectory
        Vector3 targetPosition = CalculateTargetPosition();
        Vector3 initialVelocity = CalculateInitialVelocity(targetPosition);

        // Apply the initial velocity to the rigidbody
        GetComponent<Rigidbody>().velocity = initialVelocity;
    }

    private void UpdatePosition()
    {
        // Update the position based on the parabolic trajectory
        timeElapsed += Time.deltaTime;
        transform.position = CalculateProjectilePosition(initialPosition, initialSpeed, gravity, timeElapsed);
    }

    private Vector3 CalculateTargetPosition()
    {
        // Calculate the target position (e.g., the position of the player)
        // You may replace this with your specific logic to determine the target position
        return player.position;
    }

    private Vector3 CalculateInitialVelocity(Vector3 targetPosition)
    {
        // Calculate the initial velocity required for the desired trajectory
        Vector3 displacement = targetPosition - initialPosition;
        float timeToReachTarget = Mathf.Sqrt(2 * displacement.y / gravity);

        // Calculate the initial velocity using time of flight formula
        Vector3 initialVelocity = displacement / timeToReachTarget;

        // Adjust the vertical component to account for gravity
        initialVelocity.y = Mathf.Sqrt(2 * gravity * displacement.y);

        return initialVelocity;
    }

    private Vector3 CalculateProjectilePosition(Vector3 initialPos, float initialSpeed, float gravity, float time)
    {
        // Calculate the position of the projectile at a given time
        float x = initialPos.x + initialSpeed * time;
        float y = initialPos.y + (initialSpeed * time - 0.5f * gravity * time * time);
        float z = initialPos.z;

        return new Vector3(x, y, z);
    }
}
