using System;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour {

    public List<GameObject> vehicles;
    public GameObject choosenVehicle;
    public int vehicleDirection;
    public float spawnTime;
    private float timer;

	// Use this for initialization
	void Start () {
		if(!choosenVehicle && vehicles.Count > 0)
        {
            choosenVehicle = vehicles[UnityEngine.Random.Range(0,vehicles.Count)];
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
        if (choosenVehicle)
        {
            GameObject vehicle = Instantiate(choosenVehicle, transform.position, transform.rotation);
            vehicle.GetComponent<Vehicle>().SetDirection(vehicleDirection);
        }
    }
}
