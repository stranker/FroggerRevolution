using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtles : MonoBehaviour {

    public int immerseTime;
    public float immerseZPos;
    private float timer;
    private float initialZPos;
    public bool immerse;

	// Use this for initialization
	void Start () {
        immerse = false;
        initialZPos = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= immerseTime)
        {
            Vector3 newPos = transform.position;
            if (!immerse)
            {
                immerse = true;
                newPos.z = immerseZPos;
            }
            else
            {
                immerse = false;
                newPos.z = initialZPos;
            }
            transform.position = newPos;
            timer = 0;
        }
	}
}
