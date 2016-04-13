using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;

    public float interpTime = 3f;
    public float playerSizeCameraChangeMultiplier;
    public float playerSpeedCameraChangeMultiplier;
    private float u;
    private Vector3 originOffset;
    private bool openingPan = true;

    public Vector3 regularGravityOffset;
    public Vector3 inverseGravityOffset;
	public static CameraFollow C;
    public float verticalLensShiftOffset;

    public bool freeze = false;

	void Awake() {
		C = this;
	}

	// Use this for initialization
	void Start () {
        player = Player.S.gameObject;
        offset = regularGravityOffset;
        originOffset = transform.position;
		player = Player.S.gameObject;
	}

    // Update is called once per frame
    void Update() {
        if (freeze)
        {
            return;
        }
        SetObliqueness(0, verticalLensShiftOffset);
        u = u + Time.deltaTime;
        Vector3 playerSizeCameraChange = new Vector3(0, 0, -Vector3.Magnitude(player.transform.localScale)) * playerSizeCameraChangeMultiplier;
        Vector3 playerSpeedCameraChange = new Vector3(0, 0, -Vector3.Magnitude(player.GetComponent<Rigidbody>().velocity)) * playerSpeedCameraChangeMultiplier;
        if (u < interpTime) {
            transform.position = player.transform.position + ((interpTime - u) * originOffset + u * (offset + playerSizeCameraChange + playerSpeedCameraChange)) / interpTime;
        }
        else
        {
            transform.position = player.transform.position + offset + playerSizeCameraChange + playerSpeedCameraChange;
            openingPan = false;
        }

        if (!openingPan)
        {
            Player.S.allowMovement = true;
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

    void SetObliqueness(float horizObl, float vertObl)
    {
        Matrix4x4 mat = Camera.main.projectionMatrix;
        mat[0, 2] = horizObl;
        mat[1, 2] = vertObl;
        Camera.main.projectionMatrix = mat;
    }
}
