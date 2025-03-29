using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 impact = Vector3.zero;
    public float pushDecay = 5f; // Speed at which push effect fades

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (impact.magnitude > 0.2f) // Only move if impact is strong
        {
            controller.Move(impact * Time.deltaTime);
            impact = Vector3.Lerp(impact, Vector3.zero, pushDecay * Time.deltaTime); // Smoothly reduce impact force
        }
    }

    public void ApplyPush(Vector3 force)
    {
        impact += force; // Add force to impact
    }
}

