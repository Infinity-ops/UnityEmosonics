using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour
{

    public int ScreenHeight { get { return Camera.main.pixelHeight; } } /**< height of screen */
    public int ScreenWidth { get { return Camera.main.pixelWidth; } } /**< width of screen*/

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}