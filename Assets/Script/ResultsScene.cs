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
        if (!GameManager.Get().gameOver)
        {
            nextButton.SetActive(true);
            result.text = "LEVEL COMPLETED";
        }
        else
        {
            result.text = "GAME OVER!";
            menuButton.SetActive(true);
        }
    }

    public void OnContinueButton()
    {
        string nextLevel = "Level" + GameManager.Get().currentLevel.ToString();
        SceneManager.LoadScene(nextLevel);
    }

	public void OnMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        // RESET GAME STATS
    }

}
