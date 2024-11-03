using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour   // MoveLeft simply moves the backround and spawned obstacle- and oil-prefabs to the left.
{
    public GameObject player;
    private PlayerController_3 playerControllerScript;

    public float speed = 30;
    public float leftBound = -15;

    public int spawnDelay = 3;


    private void Start()
    {
        // Finding the script is a better option than simply dragging it when the project starts to grow.
        playerControllerScript = GameObject.Find("Player").GetComponent < PlayerController_3>();
    }
    
    void Update()
    {
        if (playerControllerScript.gameOver == false)   // As long as gameOver = false, we continue the movement.
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Destroy objects if they cross the left treshold.

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Barrel"))
        {
            Destroy(gameObject);
        }
    }

    
}
