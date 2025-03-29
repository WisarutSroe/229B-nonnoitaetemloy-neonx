using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float iceControl = 0.1f; // Lower value makes it harder to stop
    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 targetVelocity = new Vector3(moveX, 0, moveZ) * moveSpeed;
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, iceControl);
    }
}

