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
            StartCoroutine(FadeIn(obstaclePrefab));

        }
    }



    IEnumerator FadeIn(GameObject obstacle)
    {
        // Get the Renderer component of the instantiated object
        Renderer obstacleRenderer = obstacle.GetComponent<Renderer>(); // Get the Renderer, not Color

        // Set the initial color to transparent (alpha = 0)
        Color obstacleColor = obstacleRenderer.material.color;
        obstacleColor.a = 0f; // Fully transparent
        obstacleRenderer.material.color = obstacleColor;

        // Gradually increase the alpha value to make the object visible
        float fadeDuration = 2f; // Duration of the fade-in effect
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            // Interpolate the alpha value over time
            obstacleColor.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            obstacleRenderer.material.color = obstacleColor;
            yield return null; // Wait for the next frame
        }

        // Ensure the final alpha is set to 1 (fully visible)
        obstacleColor.a = 1f;
        obstacleRenderer.material.color = obstacleColor;
    }
}
