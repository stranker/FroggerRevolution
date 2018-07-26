using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {
    public int walkDistance = 1;
    public float cameraHeight;
    public float cameraWidth;
    public float positionOffset = 0.5f;
	// Use this for initialization
	void Start () {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Mathf.FloorToInt(Camera.main.aspect * cameraHeight);
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        CheckOOB();
    }

    private void CheckOOB()
    {
        Vector3 position = transform.position;
        if (transform.position.x > cameraWidth - positionOffset)
        {
            position.x = cameraWidth - positionOffset;
        }
        else if (transform.position.x < -cameraWidth + positionOffset)
        {
            position.x = -cameraWidth + positionOffset;
        }
        if (transform.position.y > cameraHeight - positionOffset)
        {
            position.y = cameraHeight - positionOffset;
        }
        else if (transform.position.y < -cameraHeight + positionOffset)
        {
            position.y = -cameraHeight + positionOffset;
        }
        transform.position = position;
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement.y += walkDistance;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement.y -= walkDistance;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement.x += walkDistance;
            Debug.Log(cameraWidth);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log(cameraWidth);
            movement.x -= walkDistance;
        }
        transform.position += movement;
    }
}
