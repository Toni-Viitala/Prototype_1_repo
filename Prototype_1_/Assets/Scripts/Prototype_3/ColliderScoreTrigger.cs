using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScoreTrigger : MonoBehaviour   // Add this code to Objects/Prefabs that add to the player score. (In StatsManager.score)
{
    public StatsManager statsManager;
    public GameObject barrel;
    private void Start()
    {
        statsManager = FindObjectOfType<StatsManager>();
        if (statsManager == null)
        {
            Debug.LogError("StatsManager not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other) // If player collides these we add points to statsmanager, if it is a barrel, we destroy it.
    {
        if (other.CompareTag("Player"))     
        {
            statsManager.score++;
        }
        if (other.CompareTag("Player"))
        {
            Destroy(barrel);
        }
        
    }

}
