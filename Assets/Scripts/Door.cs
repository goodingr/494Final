using UnityEngine;
using System.Collections;


public class Door : MonoBehaviour {

    public float moveDuration = 1f;
    public float openOffset = 3f;
    enum State {Open, Closed, Opening, Closing};


    Vector3 posClosed;
    Vector3 posOpen;
    float moveStart;
    
    State state = State.Closed;
    
	// Use this for initialization
	void Start () {
	    posClosed = transform.position;
        posOpen = posClosed;
        posOpen.y += openOffset;
	}
	
	// Update is called once per frame
	void Update () {
	    if (state == State.Opening) {
            if(Time.time < moveStart + moveDuration)
            {
                float u = Time.time - moveStart;
                u = Mathf.Pow(u, 2);

            Vector3 pos = (1-u) * posClosed + u * posOpen;
            
            transform.position = pos;  
            }
            else {
                state = State.Open;
            }
        }
        else if (state == State.Closing) {
            if(Time.time < moveStart + moveDuration)
            {
                float u = Time.time - moveStart;

                Vector3 pos = (1-u) * posOpen + u * posClosed;

                transform.position = pos;  
            }
            else {
                state = State.Closed;
            }
        }
	}
    
    public void Open() {
        state = State.Opening;
        moveStart = Time.time;
    }
    public void Close() {
        state = State.Closing;
        moveStart = Time.time;
    }
}
