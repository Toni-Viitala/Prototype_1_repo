using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_3 : MonoBehaviour
{
    private PlayerController_3 playerControllerScript;

    public GameObject obstaclePrefab;
    public Vector3 spawnPosition = new Vector3(25,0,0);

    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController_3>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
        
    }
}
