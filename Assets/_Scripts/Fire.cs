using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public GameObject smoke;
	public GameObject pickdown;
	public AudioSource audio;
	public bool triggered;
	public GameObject triggerObject;
	public bool putOutTriggered;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		triggered = false;
		putOutTriggered = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player" && !triggered) {
			Instantiate (smoke, transform.position, Quaternion.identity);
			audio.Play ();
			triggered = true;
			triggerObject.GetComponent<Balloon> ().setTrigger ();
			//Destroy (gameObject);
		}
		if (col.gameObject.tag == "MoveableObject" && !putOutTriggered) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			triggerObject.GetComponent<Balloon> ().setPutOutTrigger ();
		}
	}
}
