using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	float speed = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(speed * Time.deltaTime, 0,0);
	}
	
	void OnCollisionEnter() {
		//gameObject refers to the object that this script is a component of.
		Destroy(gameObject);
	}
}
