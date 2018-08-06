using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScene : MonoBehaviour {

	public void OnAnimationFinished()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
