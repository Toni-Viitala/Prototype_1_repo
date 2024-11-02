using UnityEngine;
using TMPro; // Include the TextMesh Pro namespace

public class ScoreManager : MonoBehaviour
{
    public PlayerController_3 playerController;

    public static int score = 0; // Score variable to keep track of the player's score
    public TextMeshProUGUI scoreText; // Reference to the TextMesh Pro UI component

    void Update()
    {
        scoreText.text = "Score: " + score; // Update the score display

        if (playerController.gameOver == true)
        {
            score = 0;
        }

    }

    public void AddScore(int amount)
    {
        score += amount; // Increase the score by the specified amount
    }

    
}
