using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public List<GameObject> objects;
    public GameObject choosenObject;
    public int vehicleDirection;
    public float spawnTime;
    private float timer;

	// Use this for initialization
	void Start () {
		if(!choosenObject && objects.Count > 0)
        {
            choosenObject = objects[UnityEngine.Random.Range(0, objects.Count)];
        }
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnVehicle();
            timer = 0;
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
