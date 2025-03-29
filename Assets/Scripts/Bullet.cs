using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Bullet speed
    public float damage = 10f; // Bullet damage (optional)
    public float lifeTime = 3f; // Bullet lifetime before it gets destroyed

    void Start()
    {
        // Destroy bullet after its lifetime ends
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Check if the bullet hits an enemy
        {
            Debug.Log("Hit " + other.name);
            Destroy(other.gameObject); // Destroy the enemy (optional)
            Destroy(gameObject); // Destroy the bullet
        }
    }
}



