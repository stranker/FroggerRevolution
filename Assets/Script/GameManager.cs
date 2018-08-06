using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject frog;
    public bool gameOver;
    public int currentLevel;
    public int score;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        frog = GameObject.FindGameObjectWithTag("Frog");
        currentLevel = 1;
        score = 0;
    }

    public static GameManager Get()
    {
        return instance;
    }

    public void EndLevel()
    {
        currentLevel++;
        if (currentLevel >= 4)
        {
            gameOver = true;
        }
        SceneManager.LoadScene("ResultScene");
    }

    public void GameOver()
    {
        gameOver = true;
        EndLevel();
    }

}
