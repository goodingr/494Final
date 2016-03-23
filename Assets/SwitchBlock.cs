using UnityEngine;
using System.Collections;

public class SwitchBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Player") {
			Player.S.switchable = true;

			if(Input.GetKeyDown("space"))
				Player.S.transform.position = gameObject.transform.position;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player") {
			Player.S.switchable = false;
		}
	}
}