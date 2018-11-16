using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class LoadingScene : MonoBehaviour
{
    private bool loadscene = false;
    public string LoadingSceneName;
    public Text loadingText;
    public Slider sliderBar;
    float progress;
    // Use this for initialization
    void Awake()
    {
        StartCoroutine(LoadNewScene(LoadingSceneName));
    }

    // Update is called once per frame

    /**
	 * This manages to load scene after the while
	 */
    IEnumerator LoadNewScene(string sceneName)
    {
        sliderBar.gameObject.SetActive(true);

        yield return new WaitForSeconds(5);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
           progress = Mathf.Clamp01(operation.progress / .9f);

            loadingText.text = progress * 100 + "%";
            yield return null;

        }
        


    }

}
