using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    int randomSpawnTime;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        int randomSpawnTime = Random.Range(3,5); 
        InvokeRepeating("SpawnRandomBall", startDelay, randomSpawnTime);
        // The tutorial wanted the spawn time to be random, so it's randomized at the start and then each cycle in the SpawnRandomBall()-method.
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        int randomizedList = Random.Range(0, ballPrefabs.Length); // Select a random member from the list between 0 - and the last member from the list.
        

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        randomSpawnTime = Random.Range(3,5); Debug.Log("randomSpanwTime is : " + randomSpawnTime);  // Let's check that our method randomizes properly.

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomizedList], spawnPos, ballPrefabs[randomizedList].transform.rotation);
    }


}
