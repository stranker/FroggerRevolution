using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public Vector3 frogInitialPos;
    public int spotsCount;
    public int spotsReached;

	// Use this for initialization
	void Start () {
        spotsReached = 0;
        GameObject[] finalSpots = GameObject.FindGameObjectsWithTag("FinalSpot");
        foreach (GameObject spot in finalSpots)
        {
            spot.GetComponent<FinalSpot>().SetLevelManager(gameObject);
            spotsCount++;
        }
	}

    public void AddSpotReached()
    {
        spotsReached++;
        if (spotsReached >= spotsCount)
        {
            GameManager.Get().EndLevel();
        }
        else
        {
            GameManager.Get().frog.GetComponent<Frog>().GoToInitialPos();
        }
    }
	
}
