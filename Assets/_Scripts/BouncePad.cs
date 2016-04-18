using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour {

	public AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision coll) {
		if(coll.gameObject.tag == "Player") {
			audio.Play();
		}
	}
}
