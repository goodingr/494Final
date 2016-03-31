using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour
{

    public Vector3 startPos;
    public int numStops;
    public float stopHeight;
    public float floorWaitTime;
    public float timeBetweenFloors;

    private int directionToggle = 1;
    private float floorTime = 0;
    private float u = 0;
    private Vector3 lastFloorPos;
    private Vector3 nextFloorPos;

    // Use this for initialization
    void Start()
    {
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
            if (directionToggle == 1 && startPos.y + (numStops-1) * stopHeight == transform.position.y)
            {
                directionToggle = -1;
            }
            else if (directionToggle == -1 && transform.position == startPos)
            {
                directionToggle = 1;
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
}
