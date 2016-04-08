using UnityEngine;
using System.Collections;

public class Pickdown : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Player.S.Exude(this.gameObject);
        }
    }
}
