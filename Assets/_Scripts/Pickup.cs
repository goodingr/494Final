using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Player.S.Absorb(this.gameObject);
        }
    }
    void OnTriggerStay(Collider other) {
        
    }


}
