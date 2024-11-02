using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_3 : MonoBehaviour
{
    private PlayerController_3 playerControllerScript;

    public GameObject obstaclePrefab;
    public GameObject oilPrefab;
    public GameObject playerPrefab;
    public Vector3 oilPosition = new Vector3(25,0,0);

    public int playerSpawnDelay = 3;
    

    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController_3>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        InvokeRepeating("SpawnOil", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, oilPosition, obstaclePrefab.transform.rotation);
            //StartCoroutine(FadeIn(obstaclePrefab));
        }
    }

    void SpawnOil()
    {
        Vector3 spawnOilPosition = new Vector3(35, Random.Range(0.0f, 8.5f), 0);
        Instantiate(oilPrefab, spawnOilPosition, obstaclePrefab.transform.rotation);
    }
}
