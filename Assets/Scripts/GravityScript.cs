﻿using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            Physics.gravity *= -1;
        }
    }
}
