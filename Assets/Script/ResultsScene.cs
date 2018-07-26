using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsScene : MonoBehaviour {
    public Text result;
    public Text score;
    public Text time;
    public GameObject nextButton;
    public GameObject menuButton;

    private void Awake()
    {
        nextButton.SetActive(false);
        menuButton.SetActive(false);
    }

    private void Start()
    {
        //if (!GameManager.Get().IsGameOver())
        //{
        //  nextButton.SetActive(true);
        //  
        //}
        //else
        //{
        //  menuButton.SetActive(true);
        //}
    }

    public void OnContinueButton()
    {
        SceneManager.LoadScene("Level"); // LEVEL + GM.level
    }

	public void OnMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        // RESET GAME STATS
    }

}
