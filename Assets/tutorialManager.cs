using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour {
  public  GameObject[] steps;
    private int step = 0;
	// Use this for initialization
	void Start () {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            child.gameObject.SetActive(false);
        }
        if (!GameControl.control.onBoardingFinished)
        {
            gameObject.SetActive(true);
        }
    }
	
    public void restartTutorial()
    {
        gameObject.SetActive(true);
        GameControl.control.onBoardingFinished = false;
        step = 0;
    }

	// Update is called once per frame
	void Update () {
        if (!GameControl.control.onBoardingFinished)
        {
            gameObject.SetActive(true);
            steps[step].SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                steps[step].SetActive(false);
                step++;
                if (step == steps.Length)
                {
                    gameObject.SetActive(false);
                    GameControl.control.onBoardingFinished = true;
                }
            }
        }
	}

    public void moveToNextStep()
    {

    }

}
