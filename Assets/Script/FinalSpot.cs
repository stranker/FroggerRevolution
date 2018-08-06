using UnityEngine;

public class FinalSpot : MonoBehaviour {

    public bool reached;
    public int score = 250;
    private GameObject levelManager;

	// Use this for initialization
	void Start () {
        reached = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Frog" && !reached)
        {
            reached = true;
            GetComponent<SpriteRenderer>().color = Color.red;
            levelManager.GetComponent<LevelManager>().AddSpotReached();
            GameManager.Get().score += score;
        }
    }

    public void SetLevelManager(GameObject lm)
    {
        levelManager = lm;
    }


}
