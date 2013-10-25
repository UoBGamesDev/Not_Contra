using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	float speed 	= 16.0f;
	float rollSpeed = 60.0f;
	float jumpSpeed = 30.0f;
	float gravity 	= 60.0f;
	float rollcapacity = 10.0f;
	float rollCounter = 0f;
	
	string horizontal;
	string vertical;
	string jump;
	string fire;
	string rollLeft;
	string rollRight;
	string grenade;
	string dropIn;
	
	public GameObject boolet;
	
	float counter;
	float fireDelay = 0.3f;
	
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		Debug.Log (gameObject.name);
		horizontal 	= ("Horizontal" 	+ gameObject.name);
		vertical 	= ("Vertical" 		+ gameObject.name);
		jump 		= ("Jump" 			+ gameObject.name);
		fire 		= ("Fire" 			+ gameObject.name);
		rollLeft 	= ("RollLeft" 		+ gameObject.name);
		rollRight 	= ("RollRight" 		+ gameObject.name);
		grenade 	= ("Grenade" 		+ gameObject.name);
		dropIn 		= ("DropIn" 		+ gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		
		moveDirection = new Vector3(deadZones(0.9f, Input.GetAxis(horizontal)) * speed, moveDirection.y, 0);
		
		if (controller.isGrounded) {
			if (Input.GetButton(jump)) {
				moveDirection.y = jumpSpeed;
			}
		}
		
		if (rollCounter > 0 && (Input.GetButton (rollRight) || Input.GetButton(rollLeft))) {
			if (Input.GetButton (rollRight) && rollCounter > 1) {
				moveDirection.x = rollSpeed;
				rollCounter -= 3 * Time.deltaTime;
			} 
		
			if (Input.GetButton (rollLeft) && rollCounter > 1) {
				moveDirection.x = -rollSpeed;
				rollCounter -= 3 * Time.deltaTime;
			}
		} else {
			if (rollCounter < rollcapacity) {
				rollCounter += Time.deltaTime;
			}
		}
		
		if (!controller.isGrounded) {
			moveDirection.y -= gravity * Time.deltaTime;
		}
		
		if (controller.collisionFlags == CollisionFlags.Above) {
			moveDirection.y = 0 - (gravity * Time.deltaTime * 2);
		}
		
		if (moveDirection.x > speed) {
			adjustSpeedLeft (moveDirection.x, speed, 10);
		}
		
		if (moveDirection.x < -speed) {
			adjustSpeedRight(moveDirection.x, -speed, 10);
		}
		
		controller.Move(moveDirection * Time.deltaTime);
		transform.position = new Vector3(transform.position.x, transform.position.y, 10.0f);
		
		if (Input.GetAxis(fire) > 0.9 & counter > fireDelay) {
			counter = 0;
			Debug.Log (counter);
			Instantiate(boolet, (transform.position + new Vector3 (1.6f, 0, 0)), transform.rotation);
		}
		
		counter += Time.deltaTime;
	}
	
	void adjustSpeedRight(float current, float desired, float increment) {
		if ((current + increment) > desired) {
			moveDirection.x = desired;
		} else {
			moveDirection.x += increment;
		}
	}
	
	void adjustSpeedLeft(float current, float desired, float increment) {
		if ((current - increment) < desired) {
			moveDirection.x = desired;
		} else {
			moveDirection.x -= increment;
		}
	}
	
	float deadZones(float zone, float input) {
		if (input > zone | input < -zone) {
			return input;
		} else {
			return 0;
		}
	}
}
