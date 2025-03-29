using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFinish : MonoBehaviour
{
    public GameObject winUI; // Assign WinPanel in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player touches the finish line
        {
            winUI.SetActive(true); // Show Win UI
            Time.timeScale = 0f; // Pause the game (optional)
        }
    }
}

