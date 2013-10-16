using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public GameObject boolet;
	float fireRate = 10f;
	float counter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (Input.GetButton("Fire1")) {
			Instantiate(boolet, (transform.position + new Vector3 (1.6f, 0, 0)), Quaternion.identity);	
		}
	
	}
}
