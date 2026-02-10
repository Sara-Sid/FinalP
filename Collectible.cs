using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for collectible items (coins, stars, etc.)
// Author: [Your Name]
// Attach this to any sphere or object you want the player to collect
// Resource: Created for Unity obstacle course project

public class Collectible : MonoBehaviour
{
	// Points awarded when collected
	public int pointValue = 10;

	// Optional: Rotate the collectible to make it spin
	public float rotateSpeed = 50f;

	void Update()
	{
		// Make the collectible spin (looks cool!)
		transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
	}

	// Called when player touches the collectible
	void OnTriggerEnter(Collider other)
	{
		// Check if the object that touched us is the Player
		if (other.CompareTag("Player"))
		{
			// Add points to the score
			ScoreManager.instance.AddPoints(pointValue);

			// Destroy this collectible
			Destroy(gameObject);
		}
	}
}
