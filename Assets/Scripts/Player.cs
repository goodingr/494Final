using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public static Player    S;
    
    private int starsCollected = 0;
    public int StarsCollected {
        get {return starsCollected;}
        
    }
    
    
    [Header("Movement")]
    public float            speed;
    
    public float scaleDuration = 1.0f;
    float scaleStart;
    public Vector3 targetScale;

    public SphereCollider col;
    
    
    private Rigidbody rigid;

	// Use this for initialization
	void Start () {
        S = this;
        targetScale = transform.localScale;
	    rigid = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	   float iH = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(iH, 0, 0.0f);
        rigid.AddForce(movement * speed);
        if (Time.time < scaleStart + scaleDuration ){
            float u = Time.time - scaleStart;

            Vector3 scale = (1-u) * transform.localScale + u*targetScale;

            transform.localScale = scale;
        }
    
	}
    
    public void Absorb(GameObject go) {
        double radius = targetScale.x/2f;

        double volume = (4.0/3.0) * System.Math.PI * System.Math.Pow(radius, 3);

        volume += (4.0/3.0) * System.Math.PI * System.Math.Pow(go.transform.localScale.x / 2.0, 3);

        radius = System.Math.Pow((3.0 * volume/(4.0 * System.Math.PI)), 1.0/3.0);
        
        
        float circ = (float) (radius * 2.0);
        
        targetScale = new Vector3(circ, circ, circ);
        scaleStart = Time.time;
        Destroy(go);
    }
    public void Exude(GameObject go) {
            
        // Calculate current volume, subtract volume of 'Pickdown' and adjust scale
        double radius = targetScale.x/2f;
        double volume = (4.0/3.0) * System.Math.PI * System.Math.Pow(radius, 3);
        volume -= (4.0/3.0) * System.Math.PI * System.Math.Pow(go.transform.localScale.x / 2.0, 3);
        radius = System.Math.Pow((3.0 * volume/(4.0 * System.Math.PI)), 1.0/3.0);

        
        float circ = (float) (radius * 2.0);
        
        if(circ < 0.5f) {
            circ = 0.5f;
        }
        
            
        targetScale = new Vector3(circ, circ, circ);
        scaleStart = Time.time;
        Destroy(go);
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Star") {
            Destroy(other.gameObject);
            starsCollected++;
            
        }
    }

}
