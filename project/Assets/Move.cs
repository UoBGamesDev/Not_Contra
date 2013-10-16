using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	float speed = 16.0f;
	float jumpSpeed = 30.0f;
	float gravity = 60.0f;
	
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		
		moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, 0);
		
		if (controller.isGrounded) {
			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}
		
		if (!controller.isGrounded) {
			moveDirection.y -= gravity * Time.deltaTime;
		}
		
		if (controller.collisionFlags == CollisionFlags.Above) {
			moveDirection.y = 0 - (gravity * Time.deltaTime * 2);
		}
		
		controller.Move(moveDirection * Time.deltaTime);
		transform.position = new Vector3(transform.position.x, transform.position.y, 10.0f);
	}
}
