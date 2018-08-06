using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject frog;
    public float cameraOffset = 1;

	// Use this for initialization
	void Start () {
        if(!frog)
            frog = GameObject.FindGameObjectWithTag("Frog");
	}
	
	// Update is called once per frame
	void Update () {
        FollowFrog();
	}

    private void FollowFrog()
    {
        Vector3 newPos = transform.position;
        newPos.x = 0;
        newPos.y = frog.transform.position.y + cameraOffset;
        transform.position = newPos;
    }
}
