using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonSelectLevel : MonoBehaviour {

	public int Scene_;

	public void SelectLevel() {
		SceneManager.LoadScene("Scene_" + Scene_);
	}
}
