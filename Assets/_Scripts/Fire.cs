using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public GameObject smoke;
	public GameObject pickdown;
	public AudioSource audio;
	public bool triggered;
	public GameObject triggerObject;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col) {
		print ("collision");
		if (col.gameObject.tag == "Player" && !triggered) {
			Instantiate (smoke, transform.position, Quaternion.identity);
			audio.Play ();
			triggered = true;
			triggerObject.GetComponent<Balloon> ().setTrigger ();
			//Destroy (gameObject);
		}
	}
}
