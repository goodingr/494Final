using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyBrick());
	}

	IEnumerator DestroyBrick() {
		yield return new WaitForSeconds(2);
		Destroy (gameObject);
	}
}
