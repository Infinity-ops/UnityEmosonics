using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    private bool loadscene = false;
    public string LoadingSceneName;
    public Text loadingText;
    public Slider sliderBar;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadNewScene(LoadingSceneName));
    }

    // Update is called once per frame
   

    IEnumerator LoadNewScene(string sceneName)
    {
        sliderBar.gameObject.SetActive(true);

        yield return new WaitForSeconds(5);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            sliderBar.value = progress;
            loadingText.text = "Loading...";
            loadingText.text = progress * 100f + "%";
            yield return null;
        }
    }


}
