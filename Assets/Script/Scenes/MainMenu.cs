using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameManager.Get())
        {
            Destroy(GameManager.Get().gameObject);
        }
	}

    public void OnPlayButton()
    {
        SceneManager.LoadScene("LoadScene");
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
