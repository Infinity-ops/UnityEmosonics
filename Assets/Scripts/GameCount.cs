using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCount : MonoBehaviour {
    public  static int scoreValue;
    public  Text score;
    

    // Use this for initialization
    void Start() {
        scoreValue = 0;
        //scoreValue = scoreValue + 1;
    }

    // Update is called once per frame
    void Update() {
        score.text = "SCORE: " + scoreValue.ToString();
    }

}
