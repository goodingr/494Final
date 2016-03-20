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
		if (col.gameObject.tag == "Player") {
			GetComponent<Rigidbody> ().useGravity = true;
		}
	}
}
