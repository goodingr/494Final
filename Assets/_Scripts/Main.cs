using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour {

    static public Main S;
    
    
	// Use this for initialization
	void Start () {
	    S = this;

	}
	
	// Update is called once per frame
	void Update () {
		float skip = Input.GetAxis ("Skip");
		if(skip > 0) {
			LoadNextLevel ();
		}
	}
	public void PlayGame() {
		SceneManager.LoadScene ("Scene_1");
	}
    public void LoadNextLevel() {
		// Reset gravity
        Physics.gravity = new Vector3(0, -10, 0);


		// Check to see if the fastest time has been beat
		string scene_name = SceneManager.GetActiveScene ().name;
		float fastest_time = PlayerPrefs.GetFloat (scene_name);
		float new_time = Display.S.time;
		if (fastest_time > new_time || fastest_time == 0f) {
			PlayerPrefs.SetFloat (scene_name, new_time);
		}

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void LoadMenu() {
		Physics.gravity = new Vector3(0, -10, 0);
		SceneManager.LoadScene ("_Menu");
	}
	public void LoadLevelSelect() {
		SceneManager.LoadScene ("_Level_Select");
	}
	public void RestartScene() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
	public void TogglePause() {
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
		else {
			Time.timeScale = 0;
		}
	}
}
