using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public int lives;
    public GameObject waterPlatform;
    private Vector3 initialPosition;
    private WaterDetect detector;
    private Vector2 lastPos;
    private float cameraHeight;
    private float cameraWidth;
    private float positionOffset = 0.5f;
    private const int walkDistance = 1;
    private const float underwaterPos = 0;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
        lives = 3;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Mathf.FloorToInt(Camera.main.aspect * cameraHeight);
        detector = GameObject.Find("WaterDetect").GetComponent<WaterDetect>();
        lastPos = transform.position;
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
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement.y -= walkDistance;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            movement.x += walkDistance;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            movement.x -= walkDistance;
        }
        if (movement.x != 0 || movement.y != 0)
        {
            lastPos = transform.position;
        }
        transform.position = transform.position + movement;
    }

    public void HitControl()
    {
        if (waterPlatform && waterPlatform.transform.position.z >= underwaterPos)
        {
            Hit();
        }
        else if (detector.onWater && !detector.onPlatform)
        {
            Hit();
        }
    }

    public void Hit()
    {
        lives--;
        if (lives <= 0)
        {
            GameManager.Get().GameOver();
        }
        GoToInitialPos();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            waterPlatform = null;
            transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            waterPlatform = collision.gameObject;
            transform.parent = waterPlatform.transform;
            Vector3 correctPos = transform.position;
            correctPos.z = initialPosition.z;
            transform.position = correctPos;
        }
        if (collision.tag == "Tilemap")
        {
            transform.position = lastPos;
        }
    }

    public void GoToInitialPos()
    {
        transform.position = initialPosition;
    }

}
