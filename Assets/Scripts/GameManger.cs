using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player; // Assign player in Inspector

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game (in case it was paused)

        // Find the start position
        GameObject startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        
        if (startPoint != null && player != null)
        {
            // Move player to the start position
            player.transform.position = startPoint.transform.position;
            player.transform.rotation = startPoint.transform.rotation;
        }
    }
}
