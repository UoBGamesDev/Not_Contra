using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public GameObject boolet;
	float fireRate = 10f;
	float counter = 0;
	
	string fire;

	// Use this for initialization
	void Start () {
		fire = ("Fire" +gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (Input.GetAxis(fire) > 0.9) {
			Instantiate(boolet, (transform.position + new Vector3 (1.6f, 0, 0)), Quaternion.identity);	
		}
	
	}
	
}
