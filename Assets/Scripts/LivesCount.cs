using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCount : MonoBehaviour
{
    public GameObject panel;  
    public static int nextLevel; //for shifting automatically to next level
    public static int livesValue = 3;
    public static int levelIncre =1;
    public Text lives;
    public Text gameStatus;
    public GameObject goToNextLevel1;
    public GameObject gameButton;
    public GameObject playGainButton;
    public static bool neverDone;
    public Image errorImage1;
    public static bool nextLevelBool;
    // Use this for initialization
    //public AudioSource _audio;
    public GameObject trajectile;//To set active TrajectileScript
    void Start()
    {
        //_audio = gameObject.GetComponent<AudioSource>();
        nextLevelBool = true;
        nextLevel = 1;
        gameStatus.enabled = false;
        goToNextLevel1.SetActive(false);
        playGainButton.SetActive(false);
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
            if (Duplicator.Game12Over == true) {
                gameStatus.text = "Successfully Completed all Levels!";
            }
            if (livesValue >= 0)
            {
                lives.text = "ATTEMPTS: " + livesValue.ToString();
            }
            // if (GameController.box == Triggertest.cloneDesCount - 1)
            if (Triggertest.cloneDesCount ==  1)
            {
               
               // Duplicator.hitter.SetActive(false);
                gameStatus.enabled = true;
                trajectile.SetActive(false);
                gameStatus.text = "Success!";
               /* string url = "http://api.voicerss.org/?key=<aee25513c7b64d3d862a6cb7c8262080>&hl=en-us&src=" + gameStatus.text;
                WWW www = new WWW(url);
                while (!www.isDone)
                {
                   
                }
                // yield return www;
                _audio.clip = www.GetAudioClip(false, true, AudioType.OGGVORBIS);
                _audio.Play(); */
               
                errorImage1.enabled = false;
                panel.SetActive(true);
                gameButton.SetActive(false);
                playGainButton.SetActive(false);
                goToNextLevel1.SetActive(true);
                //Duplicator.goToNextLevel.SetActive(true);
                GameObject.Find("SlingShot").GetComponent<SlingShot>().enabled = false;
                //GameObject.Find("DragHandle").GetComponent<DragHandle>().enabled = false;
                levelIncre = levelIncre + 1;
                neverDone = false;
                if(gameStatus.text == "Success!")
                {
   
                    nextLevel =nextLevel + 1;
                    /*
                    if (nextLevel > 1)
                    {
                        GameCount.scoreValue = GameCount.scoreValue + 5;
                        GameCount.score = "SCORE: " + GameCount.scoreValue;
                    }
                    */
                }

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
                trajectile.SetActive(false);
                GameObject.Find("SlingShot").GetComponent<SlingShot>().enabled = false;
                GameObject.Find("DragHandle").GetComponent<DragHandle>().enabled = false;
                panel.SetActive(true);
                goToNextLevel1.SetActive(false);
                gameStatus.enabled = true;
                gameButton.SetActive(false);
                gameStatus.text = "GameOver!";
                playGainButton.SetActive(true);
                //backButton.SetActive(true);
              
                if (gameStatus.text == "GameOver!")
                {
                    
                    Debug.Log("GameOverGameOverGameOverGameOverGameOverGameOverGameOverGameOverGameOverGameOverGameOverGameOverGameOverGameOver");
                    nextLevel = nextLevel-1;
                }
            }
        }
    }

}
