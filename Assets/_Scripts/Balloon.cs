using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	public static Balloon B;
	public Vector3 target;
	public Vector3 putOutTarget;
	public float speed;
	public bool triggered = false;
	public bool putOutTriggered = false;

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
		if (putOutTriggered) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, putOutTarget, step);
		}
	}

	public void setTrigger() {
		triggered = true;
		putOutTriggered = false;
	}

	public void setPutOutTrigger() {
		putOutTriggered = true;
		triggered = false;
	}
}
