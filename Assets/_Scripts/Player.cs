using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static Player    S;
	public  AudioSource audio;
    
	public bool switchable = false;
    private int starsCollected = 0;
    public int StarsCollected {
        get {return starsCollected;}
        
    }

    public Vector3 startPosition;
    private float deathTime = 0;
    public float deathRestartTime = 2;


    [Header("Movement")]
    public float            speed;
	public float 			turnMult = 4;
    public bool allowMovement = false;
    
    public float scaleDuration = 1.0f;
    float scaleStart;
    public Vector3 targetScale;

    public SphereCollider col;
	public bool rotated = false;
    public bool isMobile;
    
    private Rigidbody rigid;
    private 

    void Awake()
    {
		audio = GetComponent<AudioSource>();
        if (!S)
        {
            S = this;
        }
        else
        {
            Debug.Log("Error: Multiple player objects.");
        }
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            isMobile = true;
        }
        else
        {
            isMobile = false;
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
        if(deathTime != 0 && Time.time - deathTime > deathRestartTime)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			Physics.gravity = new Vector3(0, -10, 0);
		}
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (allowMovement)
        {
            float iH;
		
		
            if (isMobile)
            {
                iH = Input.acceleration.x;
            }
            else
            {
                iH = Input.GetAxis("Horizontal");
            }
			// This allows the player to change directions quicker.
			if (iH < 0 && rigid.velocity.x > 0 || 
				iH > 0 && rigid.velocity.x < 0) {
				iH *= turnMult;
			}
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
		audio.Play ();
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
		audio.Play ();
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
        else if(other.gameObject.tag == "FallBoundary")
        {
            CameraFollow.C.freeze = true;
            deathTime = Time.time;
        }
    }
}