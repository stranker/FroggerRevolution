using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FakeLoad : MonoBehaviour
{

    private bool loadScene = false;
    [SerializeField]
    private string scene;
    [SerializeField]
    private Text loadingText;
    [SerializeField]
    private Text levelText;


    // Updates once per frame
    void Update()
    {
        if (!loadScene)
        {
            loadScene = true;
            loadingText.text = "Loading...";
            StartCoroutine(LoadNewScene());
            if (!GameManager.Get())
            {
                levelText.text = "LEVEL 1";
                scene = "Level1";
            }
            else
            {
                levelText.text = "LEVEL " + GameManager.Get().currentLevel;
                scene = "Level" + GameManager.Get().currentLevel.ToString();
            }

        }
        if (loadScene)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
