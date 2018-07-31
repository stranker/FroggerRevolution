﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public int walkDistance = 1;
    private float cameraHeight;
    private float cameraWidth;
    private float positionOffset = 0.5f;
    private Vector3 initialPosition;
    public GameObject waterPlatform;
    private WaterDetect detector;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
        initialPosition.z = -4;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Mathf.FloorToInt(Camera.main.aspect * cameraHeight);
        detector = GameObject.Find("WaterDetect").GetComponent<WaterDetect>();
    }

    private void Update()
    {
        Movement();
        CheckOOB();
        HitControl();
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
        transform.position = transform.position + movement;
    }

    public void HitControl()
    {
        if (detector.onWater && !detector.onPlatform)
        {
            Hit();
        }
    }

    public void Hit()
    {
        transform.position = initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            waterPlatform = collision.gameObject;
            transform.parent = waterPlatform.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            waterPlatform = null;
            transform.parent = null;
        }
    }
}
