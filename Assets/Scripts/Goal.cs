using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public GameObject particles;
    private Collider col;
	// Use this for initialization
	void Start () {
	    particles = transform.Find("Particles").gameObject;
        col = transform.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    
    void OnTriggerStay(Collider other) {
        if(Utils.BoundsInBoundsCheck(other.bounds, col.bounds) == Vector3.zero) {
            particles.SetActive(true);
            
        }
    }
}
