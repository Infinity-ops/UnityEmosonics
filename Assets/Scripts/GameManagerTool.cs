using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerTool : MonoBehaviour
{
    public static bool Game12Over, overLapping, exit;
    //public EnvironmentVariableTarget protection =0;
    public Text gameStatus1;
    public GameObject myPrefab; //sphere
    public GameObject myPrefab1; //AttemptBall
    public GameObject playButton;
    public GameObject goToNextLevel;
    public GameObject playGainButton;
    public GameObject backButton;
    public GameObject ball;
    public static float xrand, yrand; //For RandomSound
    public static int a, p;
    public GameObject cc;
    public GameObject sphere;
    private GameObject attemptBall1, attemptBall2, attemptBall3;
    private RectTransform circle;
    float radius, x1, y1, z1, x0 = 0, y0 = 2.2f, g, gr, xi, yi, zi;
    float newZ, r, angle, originX = 0.0f, originY = 2.1f, prevX, prevY, currentDis;
    private Vector2[] posSPhere1;
    private Vector2[] posSPhere2;
    private Vector2[] posSPhere3;
    private Vector2[] posSPhere4;
    private Vector2[] posSPhere5;
    List<Vector2> pos1 = new List<Vector2>();
    List<Vector2> pos2 = new List<Vector2>();
    List<Vector2> pos3 = new List<Vector2>();
    List<Vector2> pos4 = new List<Vector2>();
    List<Vector2> pos5 = new List<Vector2>();
    private Vector2 testRan;
    int n_angles,q; //no.of angles
    int ran; //for random
    float[] newX, newY;
    Color[] Data;
    public Sprite ImageSprite;
    private int Width { get { return ImageSprite.texture.width; } }
    private int Height { get { return ImageSprite.texture.height; } }
    //private int ScreenHeight { get { return Camera.main.pixelHeight; } } /**< height of screen */
   // private int ScreenWidth { get { return Camera.main.pixelWidth; } } /**< width of screen*/
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
    public GameObject trajectile;//To set active TrajectileScript4
                                 //  public int systemHeight;
                                 //  public int n_angles = 5;


    void Start()
    {
        n_angles = 5;
        Game12Over = false;
        overLapping = false;
        GameObject.Find("SlingShot").GetComponent<SlingShot>().enabled = false;
        GameObject.Find("DragHandle").GetComponent<DragHandle>().enabled = false;
        trailNextLevel = 1;
        realAttemptBall = true;
        // btn.GetComponent<Button>();
        //hitter.SetActive(false);
        playGainButton.SetActive(false);
        goToNextLevel.SetActive(false);
        playButton.SetActive(true);
        Vector2 center;
        GameObject.Find("Collider").GetComponent<GameCollider>().enabled = false;
        center = cc.GetComponent<Renderer>().bounds.center;
        g = 0.0f;
        //circle = cc.GetComponent<RectTransform>();
        Data = ImageSprite.texture.GetPixels();
    }
    // TaskOnClick0() function for goToNextLevel button click
    public void TaskOnClick0()
    {
        n_angles = 5;
        ball.SetActive(true);
        trajectile.SetActive(false);
        Game12Over = false;
        overLapping = false;
        exit = false;
        var clones = GameObject.FindGameObjectsWithTag("Spheree");

        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        LivesCount.nextLevelBool = false;
        GameObject.Find("SlingShot").GetComponent<SlingShot>().enabled = true;
        GameObject.Find("DragHandle").GetComponent<DragHandle>().enabled = true;
        print(Screen.dpi);
        AttemptBall.destroy = false;
        realAttemptBall = true;
        LivesCount.neverDone = true;
        //Parameter Initialization for Game
        //GameCount.scoreValue = 0;   ///Adding score each level
        LivesCount.livesValue = 3;
        Triggertest.cloneDesCount = 0;
        // gameStatus1.enabled = false;
        panel.SetActive(false);
        // hitter.SetActive(true);
        playButton.SetActive(false);
        playGainButton.SetActive(false);
        //backButton.SetActive(false);
        
        if (AttemptBall.ballCheck1)
        {
            attemptBall1 = (GameObject)Instantiate(myPrefab1, new Vector3(-1.7f, -2.9f, 0), Quaternion.identity);
            attemptBall1.tag = "ball1";
            AttemptBall.ballCheck1 = false;

        }
        if (AttemptBall.ballCheck2)
        {

            attemptBall2 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.0f, -2.9f, 0), Quaternion.identity);
            attemptBall2.tag = "ball2";
            AttemptBall.ballCheck2 = false;

        }
        if (AttemptBall.ballCheck3)
        {

            attemptBall3 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.3f, -2.9f, 0), Quaternion.identity);
            attemptBall3.tag = "ball3";
            AttemptBall.ballCheck3 = false;
        }

    }
    // TaskOnClick1() function for goToNextLevel button click
    public void TaskOnClick1()
    {
        n_angles = 5;
        ball.SetActive(true);
        //DragHandle._ball.SetActive(true);
        trajectile.SetActive(false);
        Game12Over = false;
        overLapping = false;
        exit = false;
        LivesCount.nextLevelBool = false;
        GameObject.Find("SlingShot").GetComponent<SlingShot>().enabled = true;
        GameObject.Find("DragHandle").GetComponent<DragHandle>().enabled = true;
        //print(Screen.dpi);
        AttemptBall.destroy = false;
        realAttemptBall = true;
        LivesCount.neverDone = true;
        //Parameter Initialization for Game
        //GameCount.scoreValue = 0;   ///Adding score each level
        LivesCount.livesValue = 3;
        Triggertest.cloneDesCount = 0;
        // gameStatus1.enabled = false;
        panel.SetActive(false);
        // hitter.SetActive(true);
        playButton.SetActive(false);
        playGainButton.SetActive(false);
        //backButton.SetActive(false);
        

        attemptBall1 = (GameObject)Instantiate(myPrefab1, new Vector3(-1.7f, -2.9f, 0), Quaternion.identity);
        attemptBall1.tag = "ball1";

        attemptBall2 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.0f, -2.9f, 0), Quaternion.identity);
        attemptBall2.tag = "ball2";

        attemptBall3 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.3f, -2.9f, 0), Quaternion.identity);
        attemptBall3.tag = "ball3";
    }
    // TaskOnClick1() function for PlayAgain button click
    public void TaskOnClick2()
    {
        n_angles = 5;
        ball.SetActive(true);
        trajectile.SetActive(false);
        Game12Over = false;
        overLapping = false;
        exit = false;
        var clones = GameObject.FindGameObjectsWithTag("Spheree");

        foreach (var clone in clones)
        {

           

            Destroy(clone);

        }
        LivesCount.nextLevelBool = false;
        GameObject.Find("SlingShot").GetComponent<SlingShot>().enabled = true;
        GameObject.Find("DragHandle").GetComponent<DragHandle>().enabled = true;
        print(Screen.dpi);
        AttemptBall.destroy = false;
        realAttemptBall = true;
        LivesCount.neverDone = true;
        //Parameter Initialization for Game
        //GameCount.scoreValue = 0;   ///Adding score each level
        LivesCount.livesValue = 3;
        Triggertest.cloneDesCount = 0;
        // gameStatus1.enabled = false;
        panel.SetActive(false);
        // hitter.SetActive(true);
        playButton.SetActive(false);
        playGainButton.SetActive(false);
        //backButton.SetActive(false);
        
        if (AttemptBall.ballCheck1)
        {
            attemptBall1 = (GameObject)Instantiate(myPrefab1, new Vector3(-1.7f, -2.9f, 0), Quaternion.identity);
            attemptBall1.tag = "ball1";
            AttemptBall.ballCheck1 = false;

        }
        if (AttemptBall.ballCheck2)
        {

            attemptBall2 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.0f, -2.9f, 0), Quaternion.identity);
            attemptBall2.tag = "ball2";
            AttemptBall.ballCheck2 = false;

        }
        if (AttemptBall.ballCheck3)
        {

            attemptBall3 = (GameObject)Instantiate(myPrefab1, new Vector3(-2.3f, -2.9f, 0), Quaternion.identity);
            attemptBall3.tag = "ball3";
            AttemptBall.ballCheck3 = false;
        }
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
        

    }
    // Update is called once per frame
    void Update()
    {
        //  btn.onClick.AddListener(TaskOnClick);
    }
    public Color getColorByNormalizedPosition(float X, float Y)
    {
       
        int x = (int)(X * (Width / 6)) + (Width / 2);
        int y = (int)(Y * (Height / 5)) + (Height / 13);
        
        if (x > 0 && x < Width && y > 0 && y < Height)
        {
            return Data[y * Width + x];
        }
        return Color.black;
    }
    
    public void GameNextLevel()
    {
        //DragHandle._ball.SetActive(true);
        bool oo = false; int o = 0;
        SphereCollider sc;
       
        float b, c,  distance;
       
        a = trailNextLevel;
        q = a;
        distance = 1.95f;
       
        if (a == 2)
        {
            Game12Over = false;
            radius = 0.675f;
            distance = 2.5f;
        }
        else if (a == 3 )
        {
            Game12Over  =false;
            radius = 0.65f;
            distance = 2.45f;
        }
        else if (a == 4 )
        {
            Game12Over = false;
            radius = 0.6f;
            distance = 2.40f;
        }
        else if (a == 5 )
        {
            Game12Over = false;
            radius = 0.575f;
            distance = 2.35f;
        }
        else if (a == 6 )
        {
            Game12Over = false;
            radius = 0.55f;
            distance = 2.30f;
        }
        else if (a == 7 )
        {
            Game12Over = false;
            radius = 0.515f;
            distance = 2.25f;
        }
        else if (a == 8 )
        {
            Game12Over = false;
            radius = 0.5f;
            distance = 2.20f;
        }
        else if (a == 9 )
        {
            Game12Over = false;
            radius = 0.475f;
            distance = 2.15f;
        }
        else if (a == 10 )
        {
            Game12Over = false;
            radius = 0.45f;
            distance = 2.10f;
        }
        else if (a == 11 )
        {
            Game12Over = false;
            radius = 0.415f;
            distance = 2.05f;
        }
        else if (a == 12 )
        {
            Game12Over = false;
            radius = 0.4f;
            distance = 2.00f;
        }
        else
        {
            Game12Over = true;
            a = 0;
        }
        if (Game12Over == false)
        {
            for (int j = 1; j <= 4; j++)
            {
                for (int i = 0; i < n_angles; i++)
                {

                    if (j == 1)
                    {
                        r = 0.8f;
                        posSPhere1 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere1[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere1[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos1.Add(posSPhere1[i]);
                        // myAL.Add();
                        


                    }
                    if (j == 2)
                    {

                        posSPhere2 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere2[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere2[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos2.Add(posSPhere2[i]);
                    }
                    if (j == 3)
                    {

                        posSPhere3 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere3[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere3[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos3.Add(posSPhere3[i]);
                    }
                    if (j == 4)
                    {

                        posSPhere4 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere4[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere4[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos4.Add(posSPhere4[i]);
                    }
                    /*if (j == 5)
                    {
                       
                        posSPhere5 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere5[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere5[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.0f;
                        pos5.Add(posSPhere5[i]);
                    }*/
                }
                r += 0.5f;
                n_angles += 8;
                // positions.Add(pos1);
            }
            ran = UnityEngine.Random.Range(1, pos2.Count);
            testRan = pos2[ran];
            x1 = testRan.x;
            y1 = testRan.y;
            z1 = 3.5f;
           
            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
            sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
            sphere.gameObject.tag = "Spheree";
            sc = sphere.AddComponent<SphereCollider>();
            sc.radius = radius;
            sc.isTrigger = true;
            sphere.transform.position = new Vector3(x1, y1, z1);
           
            xrand = x1; yrand = y1;
            sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
            
            pos2.Remove(pos2[ran]);
            for (int k = 1; k <= q; k++)
            {
                if (k == 1)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                 
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos4.Remove(pos4[ran]);
                }
                if (k == 2)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);
                }
                if (k == 3)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    Debug.Log("GGGGGGGGGGGGGGGGGGGG  " + x1 + "  " + y1 + "              " + ran);
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos4.Remove(pos4[ran]);
                }
                if (k == 4)
                {
                    ran = UnityEngine.Random.Range(1, pos1.Count);
                    testRan = pos1[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    // k++;
                    pos1.Remove(pos1[ran]);
                }
                if (k == 5)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //a++;
                    pos4.Remove(pos4[ran]);
                }
                if (k == 6)
                {
                    ran = UnityEngine.Random.Range(1, pos2.Count);
                    testRan = pos2[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos2.Remove(pos2[ran]);
                }
                if (k == 7)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                 
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);
                }
                if (k == 8)
                {
                    ran = UnityEngine.Random.Range(1, pos1.Count);
                    testRan = pos1[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   

                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos1.Remove(pos1[ran]);
                }
                if (k == 9)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    // sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);
                }
                if (k == 10)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos4.Remove(pos4[ran]);

                }
                if (k == 11)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);

                }
                if (k == 12)
                {
                    ran = UnityEngine.Random.Range(1, pos2.Count);
                    testRan = pos2[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos2.Remove(pos2[ran]);

                }
                if (k == 13)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos4.Remove(pos4[ran]);
                }
            }
            levelText.text = "LEVEL: " + trailNextLevel.ToString();
            trailNextLevel++;
        }
       
    }
   
    public void GameAgain()
    {
        // DragHandle._ball.SetActive(true);
        SphereCollider sc;
        float b, c, distance;
        distance = 1.95f;
        a = trailNextLevel ;
        

        if (GameController.check == true)
        {
            p = GameController.box;
            p = trailNextLevel;
            q = p + 1;
        }
        else {
            a = trailNextLevel;
            q = a + 1;
        }
        if (a == 2 || p == 2)
        {
            Game12Over = false;
            radius = 0.675f;
            distance = 2.5f;
        }
        else if (a == 3 || p == 3)
        {
            Game12Over = false;
            radius = 0.65f;
            distance = 2.45f;
        }
        else if (a == 4 || p == 4)
        {
            Game12Over = false;
            radius = 0.615f;
            distance = 2.40f;
        }
        else if (a == 5 || p == 5)
        {
            Game12Over =false;
            radius = 0.575f;
            distance = 2.35f;
        }
        else if (a == 6 || p == 6)
        {
            Game12Over = false;
            radius = 0.55f;
            distance = 2.30f;
        }
        else if (a == 7 || p == 7)
        {
            Game12Over = false;
            radius = 0.515f;
            distance = 2.25f;
        }
        else if (a == 8 || p == 8)
        {
            Game12Over =false;
            radius = 0.5f;
            distance = 2.20f;
        }
        else if (a == 9 || p == 9)
        {
            Game12Over =false;
            radius = 0.475f;
            distance = 2.15f;
        }
        else if (a == 10 || p == 10)
        {
            Game12Over =false;
            radius = 0.45f;
            distance = 2.10f;
        }
        else if (a == 11 || p == 11)
        {
            Game12Over =false;
            radius = 0.415f;
            distance = 2.05f;
        }
        else if (a == 12 || p == 12)
        {
            Game12Over = false;
            radius = 0.4f;
            distance = 2.00f;
        }
        else
        {
            Game12Over = true;
            a = 0;
        }

        if (Game12Over == false)
        {
            for (int j = 1; j <= 4; j++)
            {
                for (int i = 0; i < n_angles; i++)
                {

                    if (j == 1)
                    {
                        r = 0.8f;
                        posSPhere1 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere1[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere1[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos1.Add(posSPhere1[i]);
                        // myAL.Add();
                        


                    }
                    if (j == 2)
                    {

                        posSPhere2 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere2[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere2[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos2.Add(posSPhere2[i]);
                    }
                    if (j == 3)
                    {

                        posSPhere3 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere3[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere3[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos3.Add(posSPhere3[i]);
                    }
                    if (j == 4)
                    {

                        posSPhere4 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere4[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere4[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos4.Add(posSPhere4[i]);
                    }
                    /*if (j == 5)
                    {
                       
                        posSPhere5 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere5[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere5[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.0f;
                        pos5.Add(posSPhere5[i]);
                    }*/
                }
                r += 0.5f;
                n_angles += 8;
                // positions.Add(pos1);
            }
            ran = UnityEngine.Random.Range(1, pos3.Count);
            testRan = pos3[ran];
            x1 = testRan.x;
            y1 = testRan.y;
            z1 = 3.5f;
           
            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
            sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
            sphere.gameObject.tag = "Spheree";
            sc = sphere.AddComponent<SphereCollider>();
            sc.radius = radius;
            sc.isTrigger = true;
            sphere.transform.position = new Vector3(x1, y1, z1);
            
            xrand = x1; yrand = y1;
            sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
            //Debug.Log(getColorByNormalizedPosition(x1, y1)); 

            pos3.Remove(pos3[ran]);
            for (int k = 1; k <= q; k++)
            {
                if (k == 1)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos4.Remove(pos4[ran]);
                }
                if (k == 2)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);
                }
                if (k == 3)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos4.Remove(pos4[ran]);
                }
                if (k == 4)
                {
                    ran = UnityEngine.Random.Range(1, pos1.Count);
                    testRan = pos1[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    // k++;
                    pos1.Remove(pos1[ran]);
                }
                if (k == 5)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //a++;
                    pos4.Remove(pos4[ran]);
                }
                if (k == 6)
                {
                    ran = UnityEngine.Random.Range(1, pos2.Count);
                    testRan = pos2[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos2.Remove(pos2[ran]);
                }
                if (k == 7)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                  

                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);
                }
                if (k == 8)
                {
                    ran = UnityEngine.Random.Range(1, pos1.Count);
                    testRan = pos1[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   

                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos1.Remove(pos1[ran]);
                }
                if (k == 9)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                  
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    // sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);
                }
                if (k == 10)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos4.Remove(pos4[ran]);

                }
                if (k == 11)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);

                }
                if (k == 12)
                {
                    ran = UnityEngine.Random.Range(1, pos2.Count);
                    testRan = pos2[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   

                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos2.Remove(pos2[ran]);

                }
                if (k == 13)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                  
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos4.Remove(pos4[ran]);
                }
                





            }
        }

    }


    public void GameTestLevel()   //Game1
    {
        // bool oo = false; int o = 0;

        a = trailNextLevel;

        SphereCollider sc;
        
        //GameController.check = true;
        float b, c, radius, distance;
        radius = 0;
        distance = 1.0f;
        if (GameController.check == true)
        {
            
            p = GameController.box;
            q = p ;
        }
        else
        {
            q = a ;

        }
       
        if (a == 1 || p == 1)
        {
            Game12Over = false;
            radius = 0.675f;
            distance = 2.5f;
        }

        else if (a == 2 || p == 2)
        {
            Game12Over = false;
            radius = 0.675f;
            distance = 2.5f;
        }
        else if (a == 3 || p == 3)
        {
            Game12Over = false;
            radius = 0.55f;
            distance = 2.45f;
        }
        else if (a == 4 || p == 4)
        {
            Game12Over = false;
            radius = 0.515f;
            distance = 2.40f;
        }
        else if (a == 5 || p == 5)
        {
            Game12Over = false;
            radius = 0.475f;
            distance = 2.35f;
        }
        else if (a == 6 || p == 6)
        {
            Game12Over = false;
            radius = 0.45f;
            distance = 2.30f;
        }
        else if (a == 7 || p == 7)
        {
            Game12Over = false;
            radius = 0.415f;
            distance = 2.25f;
        }
        else if (a == 8 || p == 8)
        {
            Game12Over = false;
            radius = 0.4f;
            distance = 2.20f;
        }
        else if (a == 9 || p == 9)
        {
            Game12Over = false;
            radius = 0.375f;
            distance = 2.15f;
        }
        else if (a == 10 || p == 10)
        {
            Game12Over = false;
            radius = 0.35f;
            distance = 2.10f;
        }
        else if (a == 11 || p == 11)
        {
            Game12Over = false;
            radius = 0.315f;
            distance = 2.05f;
        }
        else if (a == 12 || p == 12)
        {
            Game12Over = false;
            radius = 0.3f;
            distance = 2.00f;
        }
        else
        {
            
            Game12Over = true;
            a = 0;
        }

        if (Game12Over == false)
        {
            for (int j = 1; j <= 4; j++)
            {
                for (int i = 0; i < n_angles; i++)
                {

                    if (j == 1)
                    {
                        r = 0.8f;
                        posSPhere1 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere1[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere1[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos1.Add(posSPhere1[i]);
                        // myAL.Add();
                       


                    }
                    if (j == 2)
                    {

                        posSPhere2 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere2[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere2[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos2.Add(posSPhere2[i]);
                    }
                    if (j == 3)
                    {

                        posSPhere3 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere3[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere3[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos3.Add(posSPhere3[i]);
                    }
                    if (j == 4)
                    {

                        posSPhere4 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere4[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere4[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.5f;
                        pos4.Add(posSPhere4[i]);
                    }
                    /*if (j == 5)
                    {

                        posSPhere5 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere5[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere5[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.0f;
                        pos5.Add(posSPhere5[i]);
                    }*/
                }
                r += 0.5f;
                n_angles += 8;
                // positions.Add(pos1);
            }
            ran = UnityEngine.Random.Range(1, pos4.Count);
            testRan = pos4[ran];
            x1 = testRan.x;
            y1 = testRan.y;
            z1 = 3.5f;
            
            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
            sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
            sphere.gameObject.tag = "Spheree";
            sc = sphere.AddComponent<SphereCollider>();
            sc.radius = radius;
            sc.isTrigger = true;
            sphere.transform.position = new Vector3(x1, y1, z1);
           
            xrand = x1; yrand = y1;
            sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
            //Debug.Log(getColorByNormalizedPosition(x1, y1)); 

            pos4.Remove(pos4[ran]);

            for (int k = 1; k <= q; k++)
            {
                if (k == 1)
                {
                    ran = UnityEngine.Random.Range(1, pos1.Count);
                    testRan = pos1[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos1.Remove(pos1[ran]);
                }
                if (k == 2)
                {
                    ran = UnityEngine.Random.Range(1, pos2.Count);
                    testRan = pos2[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   
              
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                  
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos2.Remove(pos2[ran]);
                }
                if (k == 3)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);
                }
                if (k == 4)
                {
                    ran = UnityEngine.Random.Range(1, pos1.Count);
                    testRan = pos1[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    // k++;
                    pos1.Remove(pos1[ran]);
                }
                if (k == 5)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //a++;
                    pos4.Remove(pos4[ran]);
                }
                if (k == 6)
                {
                    ran = UnityEngine.Random.Range(1, pos2.Count);
                    testRan = pos2[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                  
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos2.Remove(pos2[ran]);
                }
                if (k == 7)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);
                }
                if (k == 8)
                {
                    ran = UnityEngine.Random.Range(1, pos1.Count);
                    testRan = pos1[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                  
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos1.Remove(pos1[ran]);
                }
                if (k == 9)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
   
                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                    
                    //xrand = x1; yrand = y1;
                    // sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);
                }
                if (k == 10)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                    

                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                   
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos4.Remove(pos4[ran]);

                }
                if (k == 11)
                {
                    ran = UnityEngine.Random.Range(1, pos3.Count);
                    testRan = pos3[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   

                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                  
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos3.Remove(pos3[ran]);

                }
                if (k == 12)
                {
                    ran = UnityEngine.Random.Range(1, pos2.Count);
                    testRan = pos2[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                   

                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                  
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos2.Remove(pos2[ran]);

                }
                if (k == 13)
                {
                    ran = UnityEngine.Random.Range(1, pos4.Count);
                    testRan = pos4[ran];
                    x1 = testRan.x;
                    y1 = testRan.y;
                 

                    myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                    sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
                    sphere.gameObject.tag = "Spheree";
                    sc = sphere.AddComponent<SphereCollider>();
                    sc.radius = radius;
                    sc.isTrigger = true;
                    sphere.transform.position = new Vector3(x1, y1, z1);
                  
                    //xrand = x1; yrand = y1;
                    sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
                    //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
                    //k++;
                    pos4.Remove(pos4[ran]);
                }
            }
            trailNextLevel++;
        }
    }
}

