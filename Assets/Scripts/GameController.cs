using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static int box; //level
    Button button;
    public static float size,distance;
    public int ScreenHeight { get { return Camera.main.pixelHeight; } }
    public int ScreenWidth { get { return Camera.main.pixelWidth; } }
    public static bool check;
    // Use this for initialization
    void Start () {
        check = false;
        //Parameter Initialization for Game
        //GameCount.scoreValue = 0;
        LivesCount.livesValue = 3;
        Triggertest.cloneDesCount = 0;
    }
	public void Find()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "button1")
        {
            box = TestLevelSlide.n1;
            print("Hey inga paaru " + box);
            check = true;
            Debug.Log(box);
            distance = 2.5f;
            size = 0.5f;
           
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button2" || LivesCount.nextLevel == 2)
        {
            box = TestLevelSlide.n2;
            check = true;
            Debug.Log(box);
            distance = 2.475f;
            size = 0.475f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button3" || LivesCount.nextLevel == 3)
        {
            box = TestLevelSlide.n3;
            check = true;
            Debug.Log(box);
            distance = 2.5f;
            size = 0.45f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button4" || LivesCount.nextLevel == 4)
        {
            box = TestLevelSlide.n4;
            check = true;
            Debug.Log(box);
            distance = 2.415f;
            size = 0.415f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button5" || LivesCount.nextLevel == 5)
        {
            box = TestLevelSlide.n5;
            check = true;
            Debug.Log(box);
            distance = 2.375f;
            size = 0.375f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button6" || LivesCount.nextLevel == 6)
        {
            box = TestLevelSlide.n6;
            check = true;
            Debug.Log(box);
            distance = 2.35f;
            size = 0.35f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button7" || LivesCount.nextLevel == 7)
        {
            box = TestLevelSlide.n7;
            check = true;
            Debug.Log(box);
            distance = 2.315f;
            size = 0.315f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button8" || LivesCount.nextLevel == 8)
        {
            box = TestLevelSlide.n8;
            check = true;
            Debug.Log(box);
            distance = 2.3f;
            size = 0.3f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button9" || LivesCount.nextLevel == 9)
        {
            box = TestLevelSlide.n9;
            check = true;
            Debug.Log(box);
            distance = 2.275f;
            size = 0.275f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button10" || LivesCount.nextLevel == 10)
        {
            box = TestLevelSlide.n10;
            check = true;
            Debug.Log(box);
            distance = 2.25f;
            size = 0.25f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button11" || LivesCount.nextLevel == 11)
        {
            box = TestLevelSlide.n11;
            check = true;
            Debug.Log(box);
            distance = 2.215f;
            size = 0.215f;
        }
         if (EventSystem.current.currentSelectedGameObject.name == "button12" || LivesCount.nextLevel == 12)
        {
            box = TestLevelSlide.n12;
            check = true;
            Debug.Log(box);
            size = 0.2f;
        }
    }
	// Update is called once per frame
	void Update () {
       

    }
   
}

