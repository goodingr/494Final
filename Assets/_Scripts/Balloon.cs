using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	public static Balloon B;
	public Vector3 target;
	public float speed;
	public bool triggered = false;

	// Use this for initialization
	void Start () {
		B = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(triggered) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
	}

	public void setTrigger() {
		triggered = true;
	}
}
