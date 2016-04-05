using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display : MonoBehaviour {
	public Text timerLabel;

	private float time = 0f;

	void FixedUpdate() {
		time += Time.deltaTime;

		int minutes = (int) time / 60; 
		int seconds = (int) time % 60;

		//update the label value
		timerLabel.text = string.Format ("{0:0}:{1:00}", minutes, seconds);

	}

}

