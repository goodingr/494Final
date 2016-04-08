using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public GameObject particles;
	static public Goal G;
    private Collider col;
	public bool levelWon = false;
	// Use this for initialization

	void Awake() {
		G = this;
	}

	void Start () {
	    particles = transform.Find("Particles").gameObject;
        col = transform.GetComponent<Collider>();

	}

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * -10);

		if (levelWon) {
			float step = 4f * Time.deltaTime;
			Player.S.transform.position = Vector3.MoveTowards(Player.S.transform.position, transform.position, step);

			float targetScale = 0f;
			float shrinkSpeed = 2f;
			Player.S.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			Player.S.transform.localScale = Vector3.Lerp(Player.S.transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime*shrinkSpeed);
		}
	}
		
    
    void OnTriggerStay(Collider other) {
        if(other.gameObject.tag != "Player") return;
        if(Utils.BoundsInBoundsCheck(other.bounds, col.bounds, BoundsTest.offScreen) == Vector3.zero) {
            //particles.SetActive(true);
            Invoke("LoadNextLevel", 3f);
			Player.S.GetComponent<Rigidbody> ().useGravity = false;
			levelWon = true;
        }
    }

    void LoadNextLevel() {
        Main.S.LoadNextLevel();
    }
}
