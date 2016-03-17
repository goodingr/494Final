using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    public float interpTime = 3f;
    private float u;
    private Vector3 originOffset;

    public Vector3 regularGravityOffset = new Vector3(0, 4.5f, -4);
    public Vector3 inverseGravityOffset = new Vector3(0, -2f, -4);

	// Use this for initialization
	void Start () {
        offset = regularGravityOffset;
        originOffset = offset;
	}
	
	// Update is called once per frame
	void Update () {
        u += Time.deltaTime;
        if (u < interpTime) {
            transform.position = player.transform.position + ((interpTime - u) * originOffset + u * offset) / interpTime;
        }
        else
        {
            transform.position = player.transform.position + offset;
        }

        if (Physics.gravity.y < 0 && offset != regularGravityOffset)
        {
            originOffset = offset;
            offset = regularGravityOffset;
            u = 0;
        }

        else if(Physics.gravity.y > 0 && offset != inverseGravityOffset)
        {
            originOffset = offset;
            offset = inverseGravityOffset;
            u = 0;
        }



        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
