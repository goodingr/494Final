using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighScores : MonoBehaviour {
	
	public Text[] highscores;

	// Use this for initialization
	void Start () {
		for(int i = 1; i <= highscores.Length; i++)
		{
			float highscore = PlayerPrefs.GetFloat ("Scene_" + i);
			int minutes = (int) highscore / 60; 
			int seconds = (int) highscore % 60;

			//update the label value
			highscores[i-1].text = string.Format ("{0:0}:{1:00}", minutes, seconds);

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
