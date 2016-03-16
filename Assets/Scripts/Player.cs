using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public static Player    S;

    public float            speed;
    public float            u = 0;
    public float scaleDuration = 1.0f;
    float scaleStart;
    public Vector3 targetScale;

    public float            pow = 1;
    public float            sinStrength = 0.2f;

    
    private Rigidbody rigid;

	// Use this for initialization
	void Start () {
        S = this;
        targetScale = transform.localScale;
	    rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	   float iH = Input.GetAxis("Horizontal");
       Vector3 movement = new Vector3(iH, 0, 0.0f);
        rigid.AddForce(movement * speed);
        if (u < scaleDuration ){
            u = Time.time - scaleStart;
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
        u = 0;
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
            u = 0;
            Destroy(go);
        }
    

}
