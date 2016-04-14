using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display : MonoBehaviour {
	public static Display S;
	public Text timerLabel;

	public float time = 0f;
	private bool timer_active = false;


	void Start() {
		S = this;
	}

	void FixedUpdate() {
		if (!timer_active)
			return;
		time += Time.deltaTime;

		int minutes = (int) time / 60; 
		int seconds = (int) time % 60;

		//update the label value
		timerLabel.text = string.Format ("{0:0}:{1:00}", minutes, seconds);

	}

	public void StartTimer() { 
		timer_active = true;
	}
	public void StopTimer() {
		timer_active = false;
	}

}

