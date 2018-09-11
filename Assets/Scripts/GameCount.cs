using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCount : MonoBehaviour {
    public static int scoreValue = 0;
    public Text score;
    

    // Use this for initialization
    void Start() {
        //scoreValue = scoreValue + 1;
    }

    // Update is called once per frame
    void Update() {
        score.text = "SCORE: " + scoreValue.ToString();
        
        if (GameObject.Find("Sphere(Clone)") == null)
        {
            //Debug.Log("Sphere Clonned");
        }
        else
        {
            //Debug.Log("Not clonned");
        }
    }

}
