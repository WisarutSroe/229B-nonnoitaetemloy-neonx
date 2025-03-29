using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPush : MonoBehaviour
{
    public float pushForce = 5f; // Adjust push strength

    private void OnCollisionEnter(Collision collision)
    {
        CharacterController controller = collision.collider.GetComponent<CharacterController>();

        if (controller != null) // Check if the player has a CharacterController
        {
            PlayerPush playerPush = collision.collider.GetComponent<PlayerPush>();
            if (playerPush != null)
            {
                Vector3 forceDirection = collision.transform.position - transform.position;
                forceDirection.y = 0; // Keep the push horizontal
                playerPush.ApplyPush(forceDirection.normalized * pushForce);
            }
        }
    }
}


