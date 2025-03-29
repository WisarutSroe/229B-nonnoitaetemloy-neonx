using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ObjectRespawner : MonoBehaviour
{
    public GameObject objectToSpawn;  // The object you want to spawn
    public Vector3 spawnPosition;     // Position to spawn the object
    public float respawnTime = 3f;    // Time between respawns in seconds

    private void Start()
    {
        // Start the respawn loop when the game starts
        StartCoroutine(RespawnObjectLoop());
    }

    // Coroutine to respawn the object at a specified interval
    IEnumerator RespawnObjectLoop()
    {
        while (true)  // Infinite loop to keep respawning
        {
            // Wait for the specified respawn time before respawning
            yield return new WaitForSeconds(respawnTime);
            
            // Spawn the object at the spawn position
            SpawnObject();
        }
    }

    // Method to spawn the object at the given position
    void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}

