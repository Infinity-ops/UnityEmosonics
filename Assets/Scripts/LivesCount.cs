using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCount : MonoBehaviour
{
  
    public static int livesValue = 5;
    public Text lives;
    public Text gameStatus;
   
    // Use this for initialization
    void Start()
    {
        gameStatus.enabled = false;
        // livesValue = livesValue + 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (livesValue>= 0)
        {
            lives.text = "ATTEMPTS: " + livesValue.ToString();
        }
        if(livesValue  <=5 && GameCount.scoreValue == 30)
        {
            gameStatus.enabled = true;
            gameStatus.text = "Success!";
        }
        if(GameCount.scoreValue < 30  && livesValue <0)
        {
            gameStatus.enabled = true;
            gameStatus.text = "GameOver!";
           
        }
    }

}
