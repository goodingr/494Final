using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
    public float rotationSpeed = 90;
	// Use this for initialization
	void Start () {
	
	}
    void FixedUpdate() {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y += rotationSpeed * Time.deltaTime;
        if(rot.y > 360) rot.y -= 360;
        else if(rot.y < 360) rot.y += 360;
        transform.rotation = Quaternion.Euler(rot);
    }
}
