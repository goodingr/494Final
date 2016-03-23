using UnityEngine;
using System.Collections;

public class FallingFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter(Collider col) {
		print ("collision in general");
		if (col.gameObject.tag == "Player") {
			print ("collision with player");
			GetComponent<Rigidbody> ().useGravity = true;
		}
	}
}
