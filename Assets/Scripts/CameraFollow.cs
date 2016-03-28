using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;

    public float interpTime = 3f;
    public float playerSizeCameraChangeMultiplier;
    private float u;
    private Vector3 originOffset;

    public Vector3 regularGravityOffset;
    public Vector3 inverseGravityOffset;

	// Use this for initialization
	void Start () {
        player = Player.S.gameObject;
        offset = regularGravityOffset;
		offset = new Vector3();
        originOffset = offset;
	}
	
	// Update is called once per frame
	void Update () {
        u = u + Time.deltaTime;
        Vector3 playerSizeCameraChange = new Vector3(0, 0, -Vector3.Magnitude(player.transform.localScale)) * playerSizeCameraChangeMultiplier;
        if (u < interpTime) {
            transform.position = player.transform.position + ((interpTime - u) * originOffset + u * (offset + playerSizeCameraChange)) / interpTime;
        }
        else
        {
            transform.position = player.transform.position + offset + playerSizeCameraChange;
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
            Physics.gravity = new Vector3(0, -10, 0);
        }
	}
}
