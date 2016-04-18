using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;
	private AudioSource current;

	private bool playing1 = false;
	private bool playing2 = false;
	private bool playing3 = false;

	// Use this for initialization
	void Start () {
		current = audio1;
		DontDestroyOnLoad(transform.gameObject);
		//audio1.Play ();
		Application.LoadLevel(1);
		StartCoroutine (level1());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator level1() {
		audio1.Play ();
		yield return new WaitForSeconds (audio1.clip.length);
		StartCoroutine(level2 ());
	}

	IEnumerator level2() {
		audio2.Play ();
		yield return new WaitForSeconds (audio2.clip.length);
		StartCoroutine(level3 ());
	}

	IEnumerator level3() {
		audio3.Play ();
		yield return new WaitForSeconds (audio3.clip.length);
		StartCoroutine(level1 ());
	}
}
