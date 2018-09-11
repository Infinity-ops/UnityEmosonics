using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCount : MonoBehaviour
{
  
    public static int livesValue = 3;
    public static int levelIncre =1;
    public Text lives;
    public Text gameStatus;
    public GameObject playGainButton;
    public GameObject backButton;
    public static bool neverDone;

    // Use this for initialization
    void Start()
    {
        gameStatus.enabled = false;
        playGainButton.SetActive(false);
        backButton.SetActive(false);
        neverDone = true;
        // livesValue = livesValue + 1;
    }
    public void CrossSceneInformation()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (neverDone)
        {
            if (livesValue >= 0)
            {
                lives.text = "ATTEMPTS: " + livesValue.ToString();
            }
            // if (GameController.box == Triggertest.cloneDesCount - 1)
            if (Triggertest.cloneDesCount ==  1)
            {
                gameStatus.enabled = true;
                gameStatus.text = "Success!";
                playGainButton.SetActive(true);
                backButton.SetActive(true);
                levelIncre = levelIncre + 1;
                neverDone = false;
            }
            /*
            if (livesValue  <= 3 && GameCount.scoreValue == 30)
            {
                gameStatus.enabled = true;
                gameStatus.text = "Success!";
            }
       
            if(GameCount.scoreValue < 30  && livesValue < 0)
            {
                gameStatus.enabled = true;
                gameStatus.text = "GameOver!";
                playGainButton.SetActive(true);
                backButton.SetActive(true);
            }
             */
            if (livesValue < 0)
            {
                gameStatus.enabled = true;
                gameStatus.text = "GameOver!";
                playGainButton.SetActive(true);
                backButton.SetActive(true);
            }
        }
    }

}
