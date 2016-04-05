using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display : MonoBehaviour {
	public Text timerLabel;

	private float time = 0f;

	void FixedUpdate() {
		time += Time.deltaTime;

		var minutes = time / 60; 
		var seconds = time % 60;

		//update the label value
		timerLabel.text = string.Format ("{0:0}:{1:00}", minutes, seconds);

	}

}

