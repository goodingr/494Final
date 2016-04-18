using UnityEngine;
using System.Collections;

public class Space_plumber : MonoBehaviour {

	public Transform startMarker;
	public Transform endMarker;
	public float speed = 5F;
	private float startTime;
	private float journeyLength;
	float endx;
	public LineRenderer lineRenderer;
	public Vector3 transforms;
	private bool tooClose = false;

    [Header("Movement")]
    public float stretchDistance = 1;
    public float verticalOffsetFromBall = 3f;

    // Use this for initialization
    void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		endMarker = Player.S.transform;
		endx = endMarker.transform.position.x;
		startMarker = transform;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}

    void FixedUpdate()
    {
        transform.position = new Vector3(Player.S.transform.position.x + Input.GetAxis("Horizontal") * stretchDistance, Player.S.transform.position.y + verticalOffsetFromBall, 0);
    }

	// Update is called once per frame
	void Update () {
		////move towards the player
		//float distCovered = (Time.time - startTime) * speed;
		//float fracJourney = distCovered / journeyLength;
	
		Vector3 vel = Player.S.GetComponent<Rigidbody> ().velocity;
		//if(vel.x >= 0 && tooClose == false)
		////transform.position = Vector3.MoveTowards(transform.position, Player.S.transform.position, speed * Time.deltaTime);
		//	transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.S.transform.position.x -  Player.S.transform.localScale.x - 2, Player.S.transform.position.y, Player.S.transform.position.z), speed * Time.deltaTime);
		//if(vel.x < 0 && tooClose == false)
		//	transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.S.transform.position.x +  Player.S.transform.localScale.x + 2, Player.S.transform.position.y, Player.S.transform.position.z), speed * Time.deltaTime);


        //Rotation
		GameObject rotateObject = new GameObject ();

		if (vel.x > 1f)
			rotateObject.transform.localEulerAngles = new Vector3 (0f, 0f, -60f);
		else if (vel.x < -1f)
			rotateObject.transform.localEulerAngles = new Vector3 (0f, 0f, 60f);
		else
			rotateObject.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
		
		float step = 5f * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateObject.transform.rotation, step);


        //LineRenderer
		lineRenderer.SetWidth(0, Player.S.transform.localScale.x);

		Vector3[] points = new Vector3[2];
		float t = Time.time;
		int i = 0;
		points [0] = transform.position;
		points [1] = Player.S.transform.position;

		lineRenderer.SetPositions(points);
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Player") {
			tooClose = true;
		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.gameObject.tag == "Player") {
			tooClose = false;
		}
	}
}

