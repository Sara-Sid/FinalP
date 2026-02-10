using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Script to manage and display the player's score
// Author: [Your Name]
// Attach this to an empty GameObject called "ScoreManager"
// Resource: Created for Unity obstacle course project

public class ScoreManager : MonoBehaviour
{
    // Singleton instance so other scripts can access this easily
    public static ScoreManager instance;

    // Current score
    private int score = 0;

	// Reference to the UI Text that displays the score
	public TextMeshProUGUI scoreText;

	void Awake()
    {
        // Set up singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize score display
        UpdateScoreDisplay();
    }

    // Call this function to add points
    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    // Update the UI text to show current score
    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // Get current score (useful for other scripts)
    public int GetScore()
    {
        return score;
    }
}

