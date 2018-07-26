using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

    public float speed;
    public float direction;

    private void Start()
    {
        if(direction == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update () {
        Movement();
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
        if (collision.tag == "Frog")
        {
            collision.GetComponent<Frog>().Die();
        }
    }

}
