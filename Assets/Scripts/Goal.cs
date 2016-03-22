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
        if(other.gameObject.tag != "Player") return;
        if(Utils.BoundsInBoundsCheck(other.bounds, col.bounds, BoundsTest.offScreen) == Vector3.zero) {
            particles.SetActive(true);
            Invoke("LoadNextLevel", 3f);
        }
    }
    void LoadNextLevel() {
        Main.S.LoadNextLevel();
    }
}
