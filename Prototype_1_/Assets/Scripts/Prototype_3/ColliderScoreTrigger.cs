using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScoreTrigger : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
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
