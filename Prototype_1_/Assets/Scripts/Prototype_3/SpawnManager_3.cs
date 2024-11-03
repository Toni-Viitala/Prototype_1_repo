using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_3 : MonoBehaviour
{
    private PlayerController_3 playerControllerScript;

    public GameObject obstaclePrefab;
    public GameObject oilPrefab;
    public GameObject playerPrefab;
    public Vector3 obstaclePosition = new Vector3(50,0,0);

    public int playerSpawnDelay = 3;
    

    private float startDelay = 2;
    public float repeatRate = 2;
    float randomSpawn = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Random spawn is START = " + randomSpawn);

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController_3>();

        StartCoroutine(SpawnObstacle());

        InvokeRepeating("SpawnOil", startDelay, repeatRate);
    }

   
    IEnumerator SpawnObstacle()
    {
    while (!playerControllerScript.gameOver)  // Continue spawning until the game is over
        {
            float randomSpawn = Random.Range(1.5f, 4);
            Debug.Log("Random spawn is = " + randomSpawn);

            Instantiate(obstaclePrefab, obstaclePosition, obstaclePrefab.transform.rotation);

            yield return new WaitForSeconds(randomSpawn);  // Wait for randomSpawn seconds before spawning the next obstacle
        }
    }

    void SpawnOil()
    {
        Vector3 spawnOilPosition = new Vector3(35, Random.Range(0.0f, 8.5f), 0);
        Instantiate(oilPrefab, spawnOilPosition, obstaclePrefab.transform.rotation);
    }
}
