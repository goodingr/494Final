using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour
{

    public Vector3 startPos;
    public int numStops;
    public float stopHeight;
    public float floorWaitTime;
    public float timeBetweenFloors;
	public AudioSource audio;

    public int directionToggle = 1;
    public float floorTime = 0;
    public float u = 0;
    public Vector3 lastFloorPos;
    public Vector3 nextFloorPos;

    // Use this for initialization
    void Start()
    {
		audio = GetComponent<AudioSource> ();
        startPos = transform.position;
        lastFloorPos = startPos;
        nextFloorPos = new Vector3(transform.position.x, transform.position.y + stopHeight * directionToggle, transform.position.z);
        floorTime = Time.time;
        u = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.y - lastFloorPos.y) > stopHeight)
        {
            lastFloorPos = nextFloorPos;
            transform.position = nextFloorPos;
            if (directionToggle == 1 && Mathf.Abs(startPos.y + (numStops - 1) * stopHeight - transform.position.y) < .05f)
            {
                directionToggle = -1;
                transform.position = new Vector3(transform.position.x, startPos.y + (numStops - 1) * stopHeight, transform.position.z);
            }
            else if (directionToggle == -1 && transform.position.y - startPos.y < .05f)
            {
                directionToggle = 1;
                transform.position = startPos;
            }
            nextFloorPos = new Vector3(transform.position.x, transform.position.y + stopHeight * directionToggle, transform.position.z);
            u = 0;
            floorTime = Time.time;
        }
        else
        {
            if (Time.time - floorTime > floorWaitTime) {
                u = u + Time.deltaTime;
                transform.position = ((timeBetweenFloors - u) * lastFloorPos + u * nextFloorPos) / timeBetweenFloors;
            }
        }
    }

	void OnCollisionEnter(Collision coll) {
		if(coll.gameObject.tag == "Player") {
			audio.Play();
		}
	}
}
