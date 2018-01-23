using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour {

	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private float jumpForce;
	[SerializeField]
	private CharacterController controller;

	private Vector3 moveDirection;
	[SerializeField]
	private float gravityScale;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = (transform.forward * Input.GetAxis ("Vertical") * moveSpeed) + (transform.right * Input.GetAxis ("Horizontal") * moveSpeed);
		if (controller.isGrounded) {
			moveDirection.y = 0f;
			if (Input.GetButtonDown ("Jump")) {
				moveDirection.y = jumpForce;
			}
		}

		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		controller.Move (moveDirection * Time.deltaTime);
	}
}
