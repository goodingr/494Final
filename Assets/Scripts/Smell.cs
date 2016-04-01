using UnityEngine;
using System.Collections;

public class Smell : MonoBehaviour {

	public float speed = 3f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float step = speed * Time.deltaTime;
		Vector3 destination = new Vector3 (Player.S.transform.position.x, Player.S.transform.position.y, Player.S.transform.position.z + 3f);
		transform.position = Vector3.MoveTowards(transform.position, destination, step);
	}
}
