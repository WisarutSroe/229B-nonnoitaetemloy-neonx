using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float mouseSensitivity = 2.0f; // Mouse sensitivity
    public Transform playerBody; // Reference to the player body (Assign in Inspector)
    private float xRotation = 0f; // Rotation around the X-axis (vertical)
    
    public float moveSpeed = 5f; // Player movement speed
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera vertically (up and down) while clamping the rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the vertical camera rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player body horizontally
        playerBody.Rotate(Vector3.up * mouseX);

        // Get input for movement (WASD or Arrow keys)
        float moveX = Input.GetAxis("Horizontal"); // Left and Right movement (A/D)
        float moveZ = Input.GetAxis("Vertical");   // Forward and Backward movement (W/S)

        // Create movement vector
        Vector3 moveDirection = (playerBody.forward * moveZ + playerBody.right * moveX).normalized;

        // Move the player (not the camera!)
        playerBody.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
