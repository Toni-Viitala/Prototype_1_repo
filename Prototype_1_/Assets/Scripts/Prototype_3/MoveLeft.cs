using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public GameObject player;
    private PlayerController_3 playerControllerScript;

    public float speed = 30;
    public float leftBound = -15;

    public int spawnDelay = 3;


    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent < PlayerController_3>();
    }
    
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

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
