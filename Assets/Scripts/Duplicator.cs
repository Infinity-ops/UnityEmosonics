﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Duplicator : MonoBehaviour {
    public Text gameStatus1;
    public GameObject myPrefab; //sphere
    public GameObject myPrefab1; //AttemptBall
    public GameObject playButton;
    public GameObject goToNextLevel;
    public GameObject playGainButton;
    public GameObject backButton;
    public static float xrand, yrand; //For RandomSound
    public static int a;
    public GameObject cc;
    public  GameObject sphere;
    private GameObject attemptBall1, attemptBall2, attemptBall3;
    private RectTransform circle;
    float radius, x1, y1, z1, x0 = 0, y0 = 2.0f, g, gr,xi, yi, zi;
    Color[] Data;
    public Sprite ImageSprite;
    public int Width { get { return ImageSprite.texture.width; } }
    public int Height { get { return ImageSprite.texture.height; } }
    public int ScreenHeight { get { return Camera.main.pixelHeight; } } /**< height of screen */
    public int ScreenWidth { get { return Camera.main.pixelWidth; } } /**< width of screen*/
    // Use this for initialization
    public static GameObject hitter; // sphere on catapult
    public GameObject panel;
    //public Button btn;
    public static bool realAttemptBall;
    public static bool testPass3; //AttemptBall Delete
    public int trailNextLevel;
    public Text levelText;
    //test
    public int systemHeight;
    public int systemWidth;
    public int renderingHeight;
    public int renderingWidth;
    //  public int systemHeight;
   
    void Start () {
        GameObject.Find("SlingShot").GetComponent<SlingShot>().enabled = false;
        GameObject.Find("DragHandle").GetComponent<DragHandle>().enabled = false;
        trailNextLevel = 2;
        realAttemptBall = true;
        // btn.GetComponent<Button>();
        //hitter.SetActive(false);
        playGainButton.SetActive(false);
        goToNextLevel.SetActive(false);
        playButton.SetActive(true);
        Vector2 center;
        GameObject.Find("Collider").GetComponent<TestColliding>().enabled = false;
        center = cc.GetComponent<Renderer>().bounds.center; 
        Debug.Log(center);
        g= 0.0f;
        circle = cc.GetComponent<RectTransform>();
        Data = ImageSprite.texture.GetPixels();
    }
    // TaskOnClick1() function for goToNextLevel button click
    public void TaskOnClick0()
    {
       
        LivesCount.nextLevelBool = false;
        GameObject.Find("SlingShot").GetComponent<SlingShot>().enabled = true;
        GameObject.Find("DragHandle").GetComponent<DragHandle>().enabled =  true;
        print(Screen.dpi);
        AttemptBall.destroy = false;
        realAttemptBall = true;
        LivesCount.neverDone = true;
        //Parameter Initialization for Game
        GameCount.scoreValue = 0;
        LivesCount.livesValue = 3;
        Triggertest.cloneDesCount = 0;
        // gameStatus1.enabled = false;
        panel.SetActive(false);
       // hitter.SetActive(true);
        playButton.SetActive(false);
        playGainButton.SetActive(false);
        //backButton.SetActive(false);
        
        Debug.Log("0000000000000000000000000000");
        if (AttemptBall.ballCheck1)
        {
            attemptBall1 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.0f, -2.9f, 0), Quaternion.identity);
            attemptBall1.tag = "ball1";
            AttemptBall.ballCheck1 = false;
        
        }
        if (AttemptBall.ballCheck2)
        {

            attemptBall2 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.3f, -2.9f, 0), Quaternion.identity);
            attemptBall2.tag = "ball2";
            AttemptBall.ballCheck2 = false;
            
        }
        if (AttemptBall.ballCheck3)
        {

            attemptBall3 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.6f, -2.9f, 0), Quaternion.identity);
            attemptBall3.tag = "ball3";
            AttemptBall.ballCheck3 = false;
        }
     
    }
    // TaskOnClick1() function for goToNextLevel button click
    public void TaskOnClick1() {
        LivesCount.nextLevelBool = false;
        GameObject.Find("SlingShot").GetComponent<SlingShot>().enabled = true;
        GameObject.Find("DragHandle").GetComponent<DragHandle>().enabled = true;
        print(Screen.dpi);
        AttemptBall.destroy = false;
        realAttemptBall = true;
        LivesCount.neverDone = true;
        //Parameter Initialization for Game
        GameCount.scoreValue = 0;
        LivesCount.livesValue = 3;
        Triggertest.cloneDesCount = 0;
        // gameStatus1.enabled = false;
        panel.SetActive(false);
        // hitter.SetActive(true);
        playButton.SetActive(false);
        playGainButton.SetActive(false);
        //backButton.SetActive(false);
        Debug.Log("0000000000000000000000000000");

        attemptBall1 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.0f, -2.9f, 0), Quaternion.identity);
        attemptBall1.tag = "ball1";

        attemptBall2 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.3f, -2.9f, 0), Quaternion.identity);
        attemptBall2.tag = "ball2";

        attemptBall3 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.6f, -2.9f, 0), Quaternion.identity);
        attemptBall3.tag = "ball3";
    }
    // TaskOnClick1() function for PlayAgain button click
    public void TaskOnClick2()
    {
        //Parameter Initialization for Game
        GameCount.scoreValue = 0;
        LivesCount.livesValue = 3;
        Triggertest.cloneDesCount = 0;
        // gameStatus1.enabled = false;
        panel.SetActive(false);
        //hitter.SetActive(true);
        playButton.SetActive(false);
        playGainButton.SetActive(false);
       // backButton.SetActive(false);
        //GameController.box = GameController.box + 1;
        Debug.Log("222222222222222222222222222222222");
    }
    public void loadByIndex(int sceneIndex)
    {
        realAttemptBall = true;
        StaticClass.CrossSceneInformation = sceneIndex.ToString();
        SceneManager.LoadScene(sceneIndex);
    }
    public static class StaticClass
    {
        public static string CrossSceneInformation { get; set; }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered*********");
        
    }
    public Color getColorByNormalizedPosition(float X, float Y){
        int x = (int)(X * (Width / 5)) + (Width / 2);
        int y = (int)(Y * (Height / 5)) + (Height / 10);
        Debug.Log("color");
        Debug.Log("Height " + Height + ", Width: " + Width + ", X: " + x + ",Y : " + y);
        if (x > 0 && x < Width && y > 0 && y < Height)
        {
            return Data[y * Width + x];
        }
        return Color.black;
    }

 
    public void Game1()
    {
    
        SphereCollider sc;
        int i;
        float b, c, radius, distance;
        a = LivesCount.nextLevel+1;
        radius = GameController.size;
        distance = GameController.distance;
        for (i = 0; i < a; i++)
        {
            Debug.Log(i);
            if (i == 0)
            {
                b = UnityEngine.Random.Range(-1.5000f, 1.50000f);
                c = UnityEngine.Random.Range(0.0000f, 3.5000f);
                if (b < -1.5000f || b < 1.50000f)
                {
                    x1 = b;
                }
                z1 = 3.5f;
                if (c < 0.00000f || c < 3.5000f)
                {
                    y1 = c;
                }
                myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                sphere.gameObject.tag = "Spheree";
                sc = sphere.AddComponent<SphereCollider>();
                sc.radius = radius;
                sc.isTrigger = true;
                sphere.transform.position = new Vector3(x1, y1, z1);
                print("**************************************");
                Debug.Log(x1 + " **" + y1);
                print("**************************************");
                xrand = x1; yrand = y1;
                sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                Debug.Log(getColorByNormalizedPosition(x1, y1));
            }
            if (i > 0)
            {
                b = UnityEngine.Random.Range(-2.39000f, 2.390000f);
                c = UnityEngine.Random.Range(-0.150000f, 4.57000f);
                if (b < -2.39000f || b < 2.390000f)
                {
                    xi = b;
                }
                zi = 3.5f;
                if (c < -0.150000f || c < 4.57000f)
                {
                    yi = c;
                }
                var deg = Math.Asin((Mathf.Sqrt((Mathf.Pow((x1), 2)) + (Mathf.Pow((y1), 2)))) / x1);
                g = Mathf.Sqrt((Mathf.Pow((xi - x0), 2)) + (Mathf.Pow((yi - y0), 2)));
                gr = Mathf.Sqrt((Mathf.Pow((xi - x1), 2)) + (Mathf.Pow((yi - y1), 2)));
                Debug.Log("G " + g);
                Debug.Log("Gr " + gr);
                //y = (float)(Math.Round((double)(UnityEngine.Random.Range(-radius, radius)), 2));
                if (g < 2.7000f)
                {
                    //sphere
                    Debug.Log("I N S I D E");
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(xi, yi, zi), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    print("**************************************");
                    Debug.Log(xi + " " + yi);
                    print("**************************************");
                    //x1rand = x1; y1rand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(xi, yi);
                }
                else
                {
                    Debug.Log("O U T S I D E");
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(0.0f, 0.0f, zi), Quaternion.identity);

                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    print("*****************\\\\*********************");
                    Debug.Log(xi + " " + yi);
                    print("******************\\\\********************");
                    // x1rand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(xi, yi);
                }
            }
        }
    }

    public void Game()
    {
        SphereCollider sc;
        int  i;
        float b, c, radius,distance;

        a = trailNextLevel+1;
        radius = GameController.size;
        distance = GameController.distance;
        for (i = 0; i < a; i++)
        {
            Debug.Log(i);
            if (i == 0)
            {
                b = UnityEngine.Random.Range(-1.5000f, 1.50000f);
                c = UnityEngine.Random.Range(0.0000f, 3.5000f);
                if (b < -1.5000f || b < 1.50000f)
                {
                    x1 = b;
                }
                z1 = 3.5f;
                if (c < 0.00000f || c < 3.5000f)
                {
                    y1 = c;
                }
                myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                sphere.gameObject.tag = "Spheree";
                sc = sphere.AddComponent<SphereCollider>();
                sc.radius = radius;
                sc.isTrigger = true;
                sphere.transform.position = new Vector3(x1, y1, z1);
                print("**************************************");
                Debug.Log(x1 + " **" + y1);
                print("**************************************");
                xrand = x1; yrand = y1;
                sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                Debug.Log(getColorByNormalizedPosition(x1, y1));
            }
            if (i > 0)
            {
                b = UnityEngine.Random.Range(-2.39000f, 2.390000f);
                c = UnityEngine.Random.Range(-0.150000f, 4.57000f);
                if (b < -2.39000f || b < 2.390000f)
                {
                    xi = b;
                }
                zi = 3.5f;
                if (c < -0.150000f || c < 4.57000f)
                {
                    yi = c;
                }
                var deg = Math.Asin((Mathf.Sqrt((Mathf.Pow((x1), 2)) + (Mathf.Pow((y1), 2)))) / x1);
                g = Mathf.Sqrt((Mathf.Pow((xi - x0), 2)) + (Mathf.Pow((yi - y0), 2)));
                gr = Mathf.Sqrt((Mathf.Pow((xi - x1), 2)) + (Mathf.Pow((yi - y1), 2)));
                Debug.Log("G " + g);
                Debug.Log("Gr " + gr);
                //y = (float)(Math.Round((double)(UnityEngine.Random.Range(-radius, radius)), 2));
                if (g < 2.7000f)
                {
                    //sphere
                    Debug.Log("I N S I D E");
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(xi, yi, zi), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    print("**************************************");
                    Debug.Log(xi + " " + yi);
                    print("**************************************");
                    //x1rand = x1; y1rand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(xi, yi);
                }
                else
                {
                    Debug.Log("O U T S I D E");
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(0.0f, 0.0f, zi), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    print("*****************\\\\*********************");
                    Debug.Log(xi + " " + yi);
                    print("******************\\\\********************");
                    // x1rand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(xi, yi);
                
            }
            }
        }
        levelText.text = "LEVEL: " + trailNextLevel.ToString();
        trailNextLevel++;
       
    }
    // Update is called once per frame
    void Update () {
      //  btn.onClick.AddListener(TaskOnClick);
    }
    public void GameAgain()
    {
        SphereCollider sc;
        int i;
        float b, c, radius, distance;

        a = trailNextLevel;
        radius = GameController.size;
        distance = GameController.distance;
        for (i = 0; i < a; i++)
        {
            Debug.Log(i);
            if (i == 0)
            {
                b = UnityEngine.Random.Range(-1.5000f, 1.50000f);
                c = UnityEngine.Random.Range(0.0000f, 3.5000f);
                if (b < -1.5000f || b < 1.50000f)
                {
                    x1 = b;
                }
                z1 = 3.5f;
                if (c < 0.00000f || c < 3.5000f)
                {
                    y1 = c;
                }
                myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                sphere.gameObject.tag = "Spheree";
                sc = sphere.AddComponent<SphereCollider>();
                sc.radius = radius;
                sc.isTrigger = true;
                sphere.transform.position = new Vector3(x1, y1, z1);
                print("**************************************");
                Debug.Log(x1 + " **" + y1);
                print("**************************************");
                xrand = x1; yrand = y1;
                sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                Debug.Log(getColorByNormalizedPosition(x1, y1));
            }
            if (i > 0)
            {
                b = UnityEngine.Random.Range(-2.39000f, 2.390000f);
                c = UnityEngine.Random.Range(-0.150000f, 4.57000f);
                if (b < -2.39000f || b < 2.390000f)
                {
                    xi = b;
                }
                zi = 3.5f;
                if (c < -0.150000f || c < 4.57000f)
                {
                    yi = c;
                }
                var deg = Math.Asin((Mathf.Sqrt((Mathf.Pow((x1), 2)) + (Mathf.Pow((y1), 2)))) / x1);
                g = Mathf.Sqrt((Mathf.Pow((xi - x0), 2)) + (Mathf.Pow((yi - y0), 2)));
                gr = Mathf.Sqrt((Mathf.Pow((xi - x1), 2)) + (Mathf.Pow((yi - y1), 2)));
                Debug.Log("G " + g);
                Debug.Log("Gr " + gr);
                //y = (float)(Math.Round((double)(UnityEngine.Random.Range(-radius, radius)), 2));
                if (g < 2.7000f)
                {
                    //sphere
                    Debug.Log("I N S I D E");
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(xi, yi, zi), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    print("**************************************");
                    Debug.Log(xi + " " + yi);
                    print("**************************************");
                    //x1rand = x1; y1rand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(xi, yi);
                }
                else
                {
                    Debug.Log("O U T S I D E");
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(0.0f, 0.0f, zi), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    print("*****************\\\\*********************");
                    Debug.Log(xi + " " + yi);
                    print("******************\\\\********************");
                    // x1rand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(xi, yi);

                }
            }
        }
     

    }
}
