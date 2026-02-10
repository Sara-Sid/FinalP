using UnityEngine;

// Camera follows the player with smooth movement
// Author: [Your Name]
// Attach this to the Main Camera
// Resource: Created for Unity obstacle course project

public class CameraFollow : MonoBehaviour
{
	// The player object to follow
	public Transform player;

	// Offset distance from player
	public Vector3 offset = new Vector3(0, 5, -8);

	// How smooth the camera follows (lower = smoother)
	public float smoothSpeed = 0.125f;

	void LateUpdate()
	{
		// Calculate desired position
		Vector3 desiredPosition = player.position + offset;

		// Smoothly move camera to desired position
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		// Always look at the player
		transform.LookAt(player);
	}
}