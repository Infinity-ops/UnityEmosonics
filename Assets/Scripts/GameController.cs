using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {
    public static int box;
    Button button;
    public static float size,distance;
    public int ScreenHeight { get { return Camera.main.pixelHeight; } }
    public int ScreenWidth { get { return Camera.main.pixelWidth; } }

    // Use this for initialization
    void Start () {
        
    }
	public void Find()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "button1")
        {
            box = TestLevelSlide.n1;
            Debug.Log(box);
            distance = 2.5f;
            size = 0.5f;
           
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button2")
        {
            box = TestLevelSlide.n2;
            Debug.Log(box);
            distance = 2.475f;
            size = 0.475f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button3")
        {
            box = TestLevelSlide.n3;
            Debug.Log(box);
            distance = 2.5f;
            size = 0.45f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button4")
        {
            box = TestLevelSlide.n4;
            Debug.Log(box);
            distance = 2.415f;
            size = 0.415f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button5")
        {
            box = TestLevelSlide.n5;
            Debug.Log(box);
            distance = 2.375f;
            size = 0.375f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button6")
        {
            box = TestLevelSlide.n6;
            Debug.Log(box);
            distance = 2.35f;
            size = 0.35f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button7")
        {
            box = TestLevelSlide.n7;
            Debug.Log(box);
            distance = 2.315f;
            size = 0.315f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button8")
        {
            box = TestLevelSlide.n8;
            Debug.Log(box);
            distance = 2.3f;
            size = 0.3f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button9")
        {
            box = TestLevelSlide.n9;
            Debug.Log(box);
            distance = 2.275f;
            size = 0.275f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button10")
        {
            box = TestLevelSlide.n10;
            Debug.Log(box);
            distance = 2.25f;
            size = 0.25f;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "button11")
        {
            box = TestLevelSlide.n11;
            Debug.Log(box);
            distance = 2.215f;
            size = 0.215f;
        }
         if (EventSystem.current.currentSelectedGameObject.name == "button12")
        {
            box = TestLevelSlide.n12;
            Debug.Log(box);
            size = 0.2f;
        }
    }
	// Update is called once per frame
	void Update () {
       

    }
   
}

