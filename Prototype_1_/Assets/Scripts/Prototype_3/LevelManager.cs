using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelManager : MonoBehaviour   // LevelManager speeds up the obstacles in 10 second intervals (InvokeRepeating"MakeItHarder") by 20 points 
                                            //and "prints" the current level. 
{
    public StatsManager statsManager;
    public SpawnManager_3 spawnManager;
    public MoveLeft  moveLeft;
    public PlayerController_3 playerController;


    public TextMeshProUGUI levelText;
    
    public int currentLevel = 1;

    public float descentSpeed = 150;
    public float resetThreshold;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = levelText.transform.position;  // This is the original place for the level text. (Outside the screen)
        moveLeft.speed = 30;    // If speed is something else we set it to 30 when the LevelManager is called.
        
        Debug.Log("Speed is at START :" + moveLeft.speed); 
        InvokeRepeating("MakeItHarder", 10.0f, 10.0f);
    }


    void Update()
    {
        levelText.text = "Level " + currentLevel;   // We print the current level using TMP.
    }

    public void MakeItHarder()
    {
        Debug.Log("MakeItHarder triggered!");

        if (playerController.gameOver)                                          // Check if the game is over
        {
            Debug.Log("Game Over. Stopping further actions in MakeItHarder.");
            return;                                                             // Stop the function if the game is over
        }

        currentLevel ++; // Incease the currentLevel by one for printing.

        moveLeft.speed += 20;   // Add speed to the MoveLeft
        Debug.Log("Speed is at UPDATE :" + moveLeft.speed);

        StartCoroutine(TextDown()); // Use a IEnumerator to drive a text across the screen.
        
    }

    IEnumerator TextDown()  // TextDown Drops the Text through the screen and then spawns it back in the start.
    {
        while (levelText != null && levelText.transform.position.y >= resetThreshold)
        {
            // Move the text down each frame
            levelText.transform.Translate(0, -descentSpeed * Time.deltaTime, 0);
            
            // Wait until the next frame before continuing the loop
            yield return null;
        }

        // Once we exit the loop, check if we need to reset the position
        if (levelText.transform.position.y < resetThreshold)
        {
            levelText.transform.position = startPosition;
        }
    }



}
