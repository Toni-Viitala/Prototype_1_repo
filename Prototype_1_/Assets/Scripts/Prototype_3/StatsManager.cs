using UnityEngine;
using TMPro; // Include the TextMesh Pro namespace

public class StatsManager : MonoBehaviour       // StatsManager takes care of printing the score and player lives - texts.
{
    public PlayerController_3 playerController;

    public int score = 0; // Score variable to keep track of the player's score
    public int playerLives = 3;

    public TextMeshProUGUI scoreText; // Reference to the TextMesh Pro UI component
    public TextMeshProUGUI livesText;
   

    void Update()
    {
        scoreText.text = "Score: " + score; // Update the score display

        livesText.text = "Lives: " + playerLives;

        if (playerController.gameOver == true)
        {
            score = 0;
        }

    }
}
