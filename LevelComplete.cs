using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script to complete level when player reaches finish with enough points
// Author: [Your Name]
// Attach this to a Finish Zone trigger object
// Resource: Created for Unity obstacle course project

public class LevelComplete : MonoBehaviour
{
	// Minimum score needed to complete level
	public int requiredScore = 100;

	// Which scene to load next (Scene 2)
	public string nextSceneName = "Level2";

	void OnTriggerEnter(Collider other)
	{
		// Check if player touched the finish zone
		if (other.CompareTag("Player"))
		{
			// Get current score
			int currentScore = ScoreManager.instance.GetScore();

			// Check if player has enough points
			if (currentScore >= requiredScore)
			{
				// Success!
				Debug.Log("Level 1 Complete! Go to Level 2");

				// Wait 2 seconds then load next scene
				StartCoroutine(LoadNextLevel());
			}
			else
			{
				// Not enough points
				int pointsNeeded = requiredScore - currentScore;
				Debug.Log("Need " + pointsNeeded + " more points to complete!");
			}
		}
	}

	IEnumerator LoadNextLevel()
	{
		// Wait 2 seconds so player can see they won
		yield return new WaitForSeconds(2f);

		// Load Scene 2
		SceneManager.LoadScene(nextSceneName);
	}
}
