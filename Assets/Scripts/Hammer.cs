using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float pushForce = 25f; // Adjust for stronger knockback
    public float upwardForce = 8f; // Helps with parkour jumps
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Ensure the player is tagged properly
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
                pushDirection.y = 0.2f; // Keep horizontal force to prevent weird rotations
                
                Vector3 finalForce = pushDirection * pushForce + Vector3.up * upwardForce;
                playerRb.velocity = Vector3.zero; // Reset velocity for consistent impact
                playerRb.AddForce(finalForce, ForceMode.Impulse);
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
