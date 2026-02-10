using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Script to control player movement and jumping
// Author: [Your Name]
// Attach this to your Player object (capsule or cube)
// Resource: Created for Unity obstacle course project

public class PlayerMovement : MonoBehaviour
{
	// Movement speed
	public float moveSpeed = 5f;

	// Jump force
	public float jumpForce = 20f;

	// Reference to the Rigidbody component
	private Rigidbody rb;

	// Ground check variables
	public bool isGrounded = true;
	public Transform groundCheck;
	public float groundDistance = 0.5f;
	public LayerMask groundMask;

	void Start()
	{
		// Get the Rigidbody component attached to this object
		rb = GetComponent<Rigidbody>();
		UnityEngine.Debug.Log("Goal: Collect 100 points!");
	}

	void Update()
	{
		// Check if player is on the ground (only if groundCheck is assigned)
		if (groundCheck != null)
		{
			isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		}

		// Get input from WASD keys using GetKey (works with both input systems)
		float moveX = 0f;
		float moveZ = 0f;

		if (Input.GetKey(KeyCode.W)) moveZ = 1f;
		if (Input.GetKey(KeyCode.S)) moveZ = -1f;
		if (Input.GetKey(KeyCode.A)) moveX = -1f;
		if (Input.GetKey(KeyCode.D)) moveX = 1f;

		// Create movement vector
		Vector3 move = new Vector3(moveX, 0, moveZ);

		// Move the player
		transform.position += move * moveSpeed * Time.deltaTime;

		// Jump when Space is pressed and player is on ground
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}
}