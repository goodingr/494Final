using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {

	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            Physics.gravity *= -1;
			audio.Play ();
        }
    }
}
