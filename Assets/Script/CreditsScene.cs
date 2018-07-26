using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour {

	public void OnBackButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
