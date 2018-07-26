using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {
    public int walkDistance = 1;
    public float cameraHeight;
    public float cameraWidth;
    public float positionOffset = 0.5f;
    private Vector2 initialPosition;

	// Use this for initialization
	void Start () {
        initialPosition = transform.position;
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
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement.x -= walkDistance;
        }
        transform.position += movement;
    }

    public void Die()
    {
        transform.position = initialPosition;
    }

}
