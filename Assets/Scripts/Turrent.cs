using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public Transform target; // The enemy/player to shoot at
    public Transform firePoint; // Where bullets are spawned
    public GameObject bulletPrefab; // Bullet prefab
    public float fireRate = 2f; // How fast the turret fires (1 bullet every 2 seconds)
    public float rotationSpeed = 5f; // Speed of aiming
    public float attackRange = 15f; // Detection range for enemies

    private float fireCooldown = 0f; // Cooldown timer for firing bullets

    void Update()
    {
        // Automatically find and set the target
        FindTarget();

        if (target == null) return;

        // Aim at the target
        AimAtTarget();

        // Fire bullets every 2 seconds
        if (fireCooldown <= 0f)
        {
            Fire();
            fireCooldown = fireRate; // Reset cooldown to fireRate (2 seconds)
        }

        // Reduce cooldown timer over time
        fireCooldown -= Time.deltaTime;
    }

    // Find the nearest target (can be player, enemy, etc.)
    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Find all enemies
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= attackRange)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform; // Set the closest enemy as the target
        }
        else
        {
            target = null; // No targets in range
        }
    }

    // Smoothly rotate the turret to face the target
    void AimAtTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    // Fire the bullet every 2 seconds
    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Spawn a new bullet
    }
}


