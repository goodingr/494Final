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

    public float lineZValue = .2f;

    [Header("Movement")]
    public float stretchDistance = 1;
    public float verticalOffsetFromBall = 3f;
    public float baseOffsetFromBall = 3f;
    public Vector3 lastGravity = Physics.gravity;
    public Vector3 curGravity = Physics.gravity;
    public float currentVerticalOffset;
    public float lastVerticalOffset;
    public float u;

    // Use this for initialization
    void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		endMarker = Player.S.transform;
		endx = endMarker.transform.position.x;
		startMarker = transform;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        currentVerticalOffset = verticalOffsetFromBall;
        lastVerticalOffset = verticalOffsetFromBall;
    }

    void FixedUpdate()
    {
        if (!CameraFollow.C.freeze)
        {
            transform.position = new Vector3(Player.S.transform.position.x + Input.GetAxis("Horizontal") * stretchDistance * Player.S.transform.localScale.x, Player.S.transform.position.y + verticalOffsetFromBall * Player.S.transform.localScale.y, 0);
        }
    }

	// Update is called once per frame
	void Update () {
        u = u + Time.deltaTime;
        if(Physics.gravity != curGravity)
        {
            u = 0;
            lastGravity = curGravity;
            curGravity = Physics.gravity;
            lastVerticalOffset = currentVerticalOffset;
            currentVerticalOffset = baseOffsetFromBall * -Physics.gravity.normalized.y;
        }
        if (verticalOffsetFromBall != currentVerticalOffset)
        {
            verticalOffsetFromBall = Mathf.Lerp(lastVerticalOffset, currentVerticalOffset, u);
        }

        //verticalOffsetFromBall = currentVerticalOffset;

        ////move towards the player
        //float distCovered = (Time.time - startTime) * speed;
        //float fracJourney = distCovered / journeyLength;

        Vector3 vel = Player.S.GetComponent<Rigidbody>().velocity;
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
        Destroy(rotateObject);

        //LineRenderer
        if (CameraFollow.C.freeze)
        {
            lineRenderer.enabled = false;
        }
        else
        {
            lineRenderer.SetWidth(0, Player.S.transform.localScale.x);

            Vector3[] points = new Vector3[2];
            float t = Time.time;
            int i = 0;
            points[0] = transform.position;
            points[1] = Player.S.transform.position;
            points[0].z = lineZValue;
            points[1].z = lineZValue;

            lineRenderer.SetPositions(points);
        }
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

