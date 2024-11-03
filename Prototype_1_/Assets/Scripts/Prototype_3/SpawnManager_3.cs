using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_3 : MonoBehaviour             // SpawnManager takes care of the spawning of the Obstacle- and oilPrefabs. 
                                                        // (Which can be found in the prefabs-folder. Not surprisingly.)
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

        InvokeRepeating("SpawnOil", startDelay, repeatRate); // We spawn oil-scoreobjects on the same interwals so InvokeRepeating suffices.

        StartCoroutine(SpawnObstacle()); // Using InvokeRepeating to spawn Obstacles would be boring since the timers cannot be changed after InvokeRepeating is run.
                                            // We randomize the spawn interval 
    }

   
    IEnumerator SpawnObstacle()
    {
    while (!playerControllerScript.gameOver)  // Continue spawning until the game is over.
        {
            float randomSpawn = Random.Range(1.5f, 4);      // Randomize
            Debug.Log("Random spawn is = " + randomSpawn);

            Instantiate(obstaclePrefab, obstaclePosition, obstaclePrefab.transform.rotation);   // Instantiate in the same position.

            yield return new WaitForSeconds(randomSpawn);  // Wait for randomSpawn seconds before spawning the next obstacle
        }
    }

    void SpawnOil() // SpawnOil Randomizes the Y-axis for the oil.
    {
        Vector3 spawnOilPosition = new Vector3(35, Random.Range(0.0f, 8.5f), 0);        // Using Random.Range to randomize Y. before Instantiating to give the
        Instantiate(oilPrefab, spawnOilPosition, obstaclePrefab.transform.rotation);    // object some unpredictability.
    }
}
