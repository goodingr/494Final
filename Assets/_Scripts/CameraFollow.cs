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
    private float currentLensShift;
    private float lastLensShift;
    private float nextLensShift;

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
        currentLensShift = verticalLensShiftOffset;
        lastLensShift = verticalLensShiftOffset;
        nextLensShift = verticalLensShiftOffset;
        SetObliqueness(0, currentLensShift);
    }

    // Update is called once per frame
    void Update() {
        if (freeze)
        {
            return;
        }
        u = u + Time.deltaTime;
        Vector3 playerSizeCameraChange = new Vector3(0, 0, -Vector3.Magnitude(player.transform.localScale)) * playerSizeCameraChangeMultiplier;
        Vector3 playerSpeedCameraChange = new Vector3(0, 0, -Vector3.Magnitude(player.GetComponent<Rigidbody>().velocity)) * playerSpeedCameraChangeMultiplier;
        if (openingPan && u < interpTime) {
            transform.position = player.transform.position + ((interpTime - u) * originOffset + u * (offset + playerSizeCameraChange + playerSpeedCameraChange)) / interpTime;
        }
        else if(u < interpTime)
        {
            transform.position = player.transform.position + ((interpTime - u) * originOffset + u * (offset + playerSizeCameraChange + playerSpeedCameraChange)) / interpTime;
            currentLensShift = Mathf.Lerp(lastLensShift, nextLensShift, u);
        }
        else
        {
            transform.position = player.transform.position + offset + playerSizeCameraChange + playerSpeedCameraChange;
            openingPan = false;
        }

        if (!openingPan)
        {
            Player.S.allowMovement = true;
            Display.S.StartTimer();
        }

        if (Physics.gravity.y < 0 && offset != regularGravityOffset)
        {
            originOffset = offset;
            offset = regularGravityOffset;
            u = 0;
            lastLensShift = currentLensShift;
            nextLensShift = verticalLensShiftOffset;
        }
        else if(Physics.gravity.y > 0 && offset != inverseGravityOffset)
        {
            originOffset = offset;
            offset = inverseGravityOffset;
            u = 0;
            lastLensShift = currentLensShift;
            nextLensShift = -verticalLensShiftOffset;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
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
