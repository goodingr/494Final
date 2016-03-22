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
	
	}
    public void LoadNextLevel() {
        Physics.gravity = new Vector3(0, -10, 0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
