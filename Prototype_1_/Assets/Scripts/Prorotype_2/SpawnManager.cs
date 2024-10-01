using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabList;

    private float spawnRangeX = 15f;
    private float spawnPositionZ = 30;

    private float startingDelay = 2f;
    private float spawnInterval = 4f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startingDelay, spawnInterval); // Kovasti n‰ps‰kk‰ metodi!
    }



    void SpawnRandomAnimal()
    {

        //if (Input.GetKeyDown(KeyCode.S)) {} // T‰t‰ ei tarvita en‰‰.

        Vector3 makeRandomSpawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);

        int randomNumberFromList = Random.Range(0, animalPrefabList.Length);
        //Mit‰ spawnataan ([]=lista), Minne spawnataan, (t‰ss‰ tapauksessa makeRandomSpawnPosition), rotaatio (t‰ss‰ tapauksessa arvotun listan j‰senen prefabin vakio)
        //Instantieate-metodin komento on muotoa (prefabNimi, transform.position, transform rotation.) Jos niit‰ ei m‰‰ritell‰ saavat ne prefabin arvon.
        Instantiate(animalPrefabList[randomNumberFromList], makeRandomSpawnPosition, animalPrefabList[randomNumberFromList].transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
