using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {
    
    

    public Door door;
    
    protected BoxCollider boxCol;    
    

    bool activated = false;
	// Use this for initialization
	void Start () {
	    boxCol = gameObject.GetComponent<BoxCollider>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnCollisionStay(Collision col) {
        if(activated) return;
        
        if(col.gameObject.tag == "Player") {
            if(Player.S.col.bounds.min.y >= boxCol.bounds.max.y - 0.01f)
            {
                Activate();
            }
        }
    }
    void Activate() {
        
        activated = true;
        door.Open();
        Vector3 pos = transform.position;
        pos.y -= transform.localScale.y - .05f; 
        transform.position = pos;
    }
}
