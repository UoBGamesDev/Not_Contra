using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	public GameObject p1, p2, p3, p4;
	public string[] players;

	// Use this for initialization
	void Start () {
		players = Input.GetJoystickNames();
		
		for (int i = 0; i < players.Length; i++) {
			if (i == 0) {
				Instantiate(p1, new Vector3(40,10,0), Quaternion.identity);
			}
			
			if (i == 1) {
				Instantiate(p2, new Vector3(45,10,0), Quaternion.identity);
			}
			
			if (i == 2) {
				Instantiate(p3, new Vector3(50,10,0), Quaternion.identity);
			}
			
			if (i == 3) {
				Instantiate(p4, new Vector3(55,10,0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
//	void Update () {
		
//	}
}