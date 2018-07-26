using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayButton()
    {
        SceneManager.LoadScene("GameLoopScene");
    }

    public void OnCreditsButton()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

}
