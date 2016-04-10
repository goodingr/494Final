using UnityEngine;
using System.Collections;

public class BrickWall : MonoBehaviour {

	public int bricks = 0;
	public GameObject brick;
	public float scale = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter (Collision coll) {
		if (coll.gameObject.tag == "Player" && 
			coll.gameObject.transform.localScale.x >= scale) {
			Destroy (gameObject);
			for (int i = 0; i < bricks; i++) {
				Instantiate (brick, transform.position, Quaternion.identity);
			}
		}
	}
}
