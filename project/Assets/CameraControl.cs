using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	Vector3 position;
	Quaternion rotation;
	float minX, maxX, minY, maxY = 0;
	public float diffX, diffY;
	GameObject[] views;
	
	public GameObject p1, p2, p3, p4;

	// Use this for initialization
	void Start () {
		views = new GameObject[] {p1,p2,p3,p4};
		Debug.Log (Input.GetJoystickNames());
	}
	
	// Update is called once per frame
	void Update () {
		viewAll (views);
		diffX = maxX - minX;
		diffY = maxY - minY;
	}
	
	float changeZoom(float minX2, float maxX2, float minY2, float maxY2) {
		Rect fov = new Rect(minX2, maxY2, (maxX2 - minX2), (maxY2 - minY2));
		
		if (fov.width > fov.height * 2) {
			float newSize = fov.width / 2.5f;
			if (newSize > 20) {
				camera.orthographicSize = newSize;
			}
		} else {
			float newSize = fov.height / 1.25f;
			if (newSize > 20) {
				camera.orthographicSize = newSize;
			}
		}
		
		//I have no idea why this is needed but it only seems to work with it, soo
		return - 10 - (fov.width * fov.height) * 0.03f;
	}
	
	//Given four players, get the leftmost and rightmost and 
	//position x between them, get the topmost and the bottommost 
	//and position y between them, and zoom out an appropriate
	//amount. Interpolate the movements (or maybe it will interpolate
	//itself?) Assume the players will be travelling left to right.
	//There will be a max zoom out level, at which point it will have
	//to decide who gets priority to stay on the screen.
	public void viewAll(GameObject[] players) {
		minX = players[0].transform.position.x;
		maxX = players[0].transform.position.x;
		minY = players[0].transform.position.y;
		maxY = players[0].transform.position.y;
		
		foreach (GameObject p in players) {
			if (p.transform.position.x <= minX) {
				minX = p.transform.position.x;
			}
			
			if (p.transform.position.x >= maxX) {
				maxX = p.transform.position.x;
			}
			
			if (p.transform.position.y <= minY) {
				minY = p.transform.position.y;
			}
			
			if (p.transform.position.y >= maxY) {
				maxY = p.transform.position.y;
			}
		}
		
		transform.position = new Vector3((minX + maxX) / 2, lowerLimit(((minY + maxY) / 2), -70), changeZoom (minX, maxX, minY, maxY));
	}
	
	float upperLimit (float input, float limit) {
		if (input > limit) {
			return limit;
		} else {
			return input;
		}
	}
	
	float lowerLimit(float input, float limit) {
		if (input < limit) {
			return limit;
		} else {
			return input;
		}
	}
}
