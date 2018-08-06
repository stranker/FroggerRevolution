using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

    public float speed;
    public float direction;
    private float cameraWidth;

    private void Start()
    {
        cameraWidth = Mathf.FloorToInt(Camera.main.aspect * Camera.main.orthographicSize);
        if (direction == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        Movement();
	}

    private void Update()
    {
        CheckOOB();
    }

    private void CheckOOB()
    {
        if (direction == -1)
        {
            if (transform.position.x < -cameraWidth - GetComponent<SpriteRenderer>().bounds.size.x)
            {
                Destroy(gameObject);
            }
        }
        else if (direction == 1)
        {
            if (transform.position.x > cameraWidth + GetComponent<SpriteRenderer>().bounds.size.x)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Movement()
    {
        Vector2 velocity = Vector2.zero;
        velocity.x = direction * speed * Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    public void SetDirection(int dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Frog" && gameObject.tag != "Platform")
        {
            collision.GetComponent<Frog>().Hit();
        }
    }
}
