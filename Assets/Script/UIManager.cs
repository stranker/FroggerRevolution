using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject controlsPanel;
    public Text scoreText;
    public Text livesText;
    public Text timeText;
    private int score = 0;
    private int lives = 0;
    private int time = 0;
    private GameManager gm;

    // Use this for initialization
    void Start() {
        pausePanel.SetActive(false);
        controlsPanel.SetActive(false);
        gm = GameManager.Get();
        UpdateLabels();
    }

    // Update is called once per frame
    void Update() {
        UpdateLabels();
    }

    private void UpdateLabels()
    {
        if (score != gm.score)
        {
            score = gm.score;
            scoreText.text = "Score \n " + score.ToString();
        }
        if (lives != gm.frog.GetComponent<Frog>().lives)
        {
            lives = gm.frog.GetComponent<Frog>().lives;
            livesText.text = "Lives \n " + lives.ToString();
        }
        if (time != gm.time)
        {
            time = gm.time;
            timeText.text = "Time \n " + time.ToString();
        }
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
