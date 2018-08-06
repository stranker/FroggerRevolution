using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public Vector3 frogInitialPos;
    public int spotsCount;
    public int spotsReached;
    private float levelTime;
    private bool spotActivated;
    private float timer;
    private int frogRepositionTime = 1;

    // Use this for initialization
    void Start () {
        GameManager.Get().frog = GameObject.FindGameObjectWithTag("Frog");
        spotsReached = 0;
        GameObject[] finalSpots = GameObject.FindGameObjectsWithTag("FinalSpot");
        foreach (GameObject spot in finalSpots)
        {
            spot.GetComponent<FinalSpot>().SetLevelManager(gameObject);
            spotsCount++;
        }
        levelTime = GameManager.Get().time;
        spotActivated = false;
	}

    private void Update()
    {
        levelTime += Time.deltaTime;
        GameManager.Get().time = (int)levelTime;
        if (spotActivated)
        {
            timer += Time.deltaTime;
            if (timer >= frogRepositionTime)
            {
                GameManager.Get().frog.GetComponent<Frog>().GoToInitialPos();
                timer = 0;
                spotActivated = false;
            }
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
            if (!spotActivated)
            {
                spotActivated = true;
            }
        }
    }
	
}
