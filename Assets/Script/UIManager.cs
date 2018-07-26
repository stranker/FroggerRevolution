using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject controlsPanel;

    // Use this for initialization
    void Start() {
        pausePanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnPauseButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnContinueButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnControlsButton()
    {
        controlsPanel.SetActive(true);
    }

    public void OnControlExitButton()
    {
        controlsPanel.SetActive(false);
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1;
    }

}
