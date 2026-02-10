using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// Movement speed
	public float moveSpeed = 5f;
	// Jump force
	public float jumpForce = 20f;
	private Rigidbody rb;

	public bool isGrounded = true;
	public Transform groundCheck;
	public float groundDistance = 0.5f;
	public LayerMask groundMask;

	void Start()
	{
		// Get the Rigidbody component attached to this object
		rb = GetComponent<Rigidbody>();
		Debug.Log("Goal: Collect 100 points!");
	}

	void Update()
	{
		// Check if player is on the ground 
		if (groundCheck != null)
		{
			isGrounded = Physics.CheckSphere
		}
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
