using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public static Player    S;
    
	public bool switchable = false;
    private int starsCollected = 0;
    public int StarsCollected {
        get {return starsCollected;}
        
    }

    [Header("Snowflake Mechanic")]
    public Vector3 startPosition;
    public GameObject frozenBall;
    public float frostPickupTime = 0;
    public float frostCountdownTime = 3;


    [Header("Movement")]
    public float            speed;
    public bool allowMovement = false;
    
    public float scaleDuration = 1.0f;
    float scaleStart;
    public Vector3 targetScale;

    public SphereCollider col;
	public bool rotated = false;
    
    private Rigidbody rigid;

    void Awake()
    {
        if (!S)
        {
            S = this;
        }
        else
        {
            Debug.Log("Error: Multiple player objects.");
        }
    }

    // Use this for initialization
    void Start () {
        targetScale = transform.localScale;
	    rigid = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        startPosition = transform.position;
	}

    void Update()
    {
        if(frostPickupTime != 0 && Time.time - frostPickupTime > frostCountdownTime)
        {
            Instantiate(frozenBall, transform.position, Quaternion.identity);
            transform.position = startPosition;
            frostPickupTime = 0;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (allowMovement)
        {
            float iH = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(iH, 0, 0.0f);
            rigid.AddForce(movement * speed);

            if (Time.time < scaleStart + scaleDuration)
            {
                float u = Time.time - scaleStart;
                Vector3 scale = (1 - u) * transform.localScale + u * targetScale;
                transform.localScale = scale;
            }
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
        else if(other.gameObject.tag == "Snowflake")
        {
            Destroy(other.gameObject);
            frostPickupTime = Time.time;
        }
    }
}