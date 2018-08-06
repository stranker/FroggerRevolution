using System;
using System.Collections.Generic;
using UnityEngine;

public class FinalSpot : MonoBehaviour {

    public bool reached;
    public int score = 250;
    public List<Sprite> sprites;
    private GameObject levelManager;

	// Use this for initialization
	void Start () {
        reached = false;
        SetSprite();
	}

    private void SetSprite()
    {
        if (sprites.Count > 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Frog" && !reached)
        {
            reached = true;
            GetComponent<SpriteRenderer>().color = Color.clear;
            levelManager.GetComponent<LevelManager>().AddSpotReached();
            GameManager.Get().score += score;
            collision.transform.position = transform.position;
        }
    }

    public void SetLevelManager(GameObject lm)
    {
        levelManager = lm;
    }


}
