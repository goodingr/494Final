using UnityEngine;
using System.Collections;

public class Space_plumber : MonoBehaviour {

	public Transform startMarker;
	public Transform endMarker;
	public float speed = 5F;
	private float startTime;
	private float journeyLength;
	float endx;

	// Use this for initialization
	void Start () {
		endMarker = Player.S.transform;
		endx = endMarker.transform.position.x;
		startMarker = transform;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}

	// Update is called once per frame
	void FixedUpdate () {
		//move towards the player
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;

		//transform.position = Vector3.Lerp(startMarker.position, new Vector3(endMarker.position.x - 1, endMarker.position.y, endMarker.position.z), fracJourney);

		transform.position = Vector3.MoveTowards(transform.position, Player.S.transform.position, speed * Time.deltaTime);

	}
}
