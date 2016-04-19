using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {
    
    

    public Door door;
    public float activeDuration = 3f;
    protected BoxCollider boxCol;  
	public AudioSource audio;
    
    float activeStart;

    bool activated = false;
	// Use this for initialization
	void Start () {
	    boxCol = gameObject.GetComponent<BoxCollider>();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	    if(activated && Time.time >= activeStart + activeDuration) {
            Deactivate();
        }
	}

    void OnCollisionStay(Collision col) {
        if (activated) return;

        if (col.gameObject.tag == "Player") {
            if (Player.S.col.bounds.min.y >= boxCol.bounds.max.y - 0.01f)
            {
                Activate();
            }
        }
        else if (col.gameObject.tag == "MoveableObject")
        {
            if (col.collider.bounds.min.y >= boxCol.bounds.max.y - 0.01f)
            {
                Activate();
            }
        }
    }
    void Activate() {
        activeStart = Time.time;
        activated = true;
        door.Open();
        Vector3 pos = transform.position;
        pos.y -= transform.localScale.y - .05f; 
        transform.position = pos;
		audio.Play ();
    }
    void Deactivate() {
        activated = false;
        door.Close();
        Vector3 pos = transform.position;
        pos.y += transform.localScale.y - .05f; 
        transform.position = pos;
    }
}
