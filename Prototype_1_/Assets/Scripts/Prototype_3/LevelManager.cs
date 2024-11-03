using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations; // Include the TextMesh Pro namespace

public class LevelManager : MonoBehaviour
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
    public int amountOfScoreNeededToChangeLevel;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = levelText.transform.position;  // Store the original position of the text
        moveLeft.speed = 30;
        
        Debug.Log("Speed is at START :" + moveLeft.speed); 
        InvokeRepeating("MakeItHarder", 10.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level " + currentLevel;
    }

    public void MakeItHarder()
    {
        Debug.Log("MakeItHarder triggered!");

        if (playerController.gameOver)  // Check if the game is over
        {
            Debug.Log("Game Over. Stopping further actions in MakeItHarder.");
            return;  // Stop the function if the game is over
        }

        currentLevel ++; 

        moveLeft.speed += 20;
        Debug.Log("Speed is at UPDATE :" + moveLeft.speed);

        StartCoroutine(TextDown());
        
    }

    IEnumerator TextDown()
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
