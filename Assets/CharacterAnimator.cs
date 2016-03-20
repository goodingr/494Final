using UnityEngine;
using System.Collections;

public class CharacterAnimator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentInParent<Rigidbody> ().velocity.x == 0) {
			Vector3 pos = GetComponentInParent<Transform> ().position;
			GetComponentInParent<Transform> ().localEulerAngles =
				new Vector3 (pos.x, 240f, 0);
		} 
	}
}
