using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public List<GameObject> objects;
    public GameObject choosenObject;
    public int vehicleDirection;
    public float spawnTime;
    private float timer;
    private float startTimer;
    private int startTime;
    private bool spawning = false;

    // Use this for initialization
    void Start () {
		if(!choosenObject && objects.Count > 0)
        {
            choosenObject = objects[UnityEngine.Random.Range(0, objects.Count)];
        }
        SpawnVehicle();
        startTime = UnityEngine.Random.Range(0, 3);
	}
	
	// Update is called once per frame
	void Update () {
        if (!spawning)
        {
            startTimer += Time.deltaTime;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > spawnTime)
            {
                SpawnVehicle();
                timer = 0;
            }
        }
        if (startTimer >= startTime)
        {
            spawning = true;
        }
	}

    private void SpawnVehicle()
    {
        if (choosenObject)
        {
            GameObject obj = Instantiate(choosenObject, transform.position, transform.rotation);
            obj.GetComponent<Vehicle>().SetDirection(vehicleDirection);
        }
    }
}
