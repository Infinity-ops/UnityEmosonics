using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Duplicator : MonoBehaviour {
    public static bool Game12Over, overLapping,exit;
    public EnvironmentVariableTarget protection =0;
    public Text gameStatus1;
    public GameObject myPrefab; //sphere
    public GameObject myPrefab1; //AttemptBall
    public GameObject playButton;
    public GameObject goToNextLevel;
    public GameObject playGainButton;
    public GameObject backButton;
    public GameObject ball;
    public static float xrand, yrand; //For RandomSound
    public static int a,p;
    public GameObject cc;
    public  GameObject sphere;
    private GameObject attemptBall1, attemptBall2, attemptBall3;
    private RectTransform circle;
    float radius, x1, y1, z1, x0 = 0, y0 = 2.2f, g, gr,xi, yi, zi;
    float  newZ, r, angle, originX= 0.0f, originY = 2.2f, prevX, prevY, currentDis;
    float[] newX, newY;
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
    public GameObject trajectile;//To set active TrajectileScript
    //  public int systemHeight;

    void Start () {
        Game12Over = false;
        overLapping = false;
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
        ball.SetActive(true);
        trajectile.SetActive(false);
        Game12Over = false;
        overLapping = false;
        exit = false;
        var clones = GameObject.FindGameObjectsWithTag("Spheree");

        foreach (var clone in clones)
        {

            Debug.Log("Gam");

            Destroy(clone);

        }
        LivesCount.nextLevelBool = false;
        GameObject.Find("SlingShot").GetComponent<SlingShot>().enabled = true;
        GameObject.Find("DragHandle").GetComponent<DragHandle>().enabled =  true;
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
        
        Debug.Log("0000000000000000000000000000");
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
    public void TaskOnClick1() {
        ball.SetActive(true);
        //DragHandle._ball.SetActive(true);
        trajectile.SetActive(false);
        Game12Over = false;
        overLapping = false;
        exit = false;
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
        Debug.Log("0000000000000000000000000000");

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
        ball.SetActive(true);
        trajectile.SetActive(false);
        Game12Over = false;
        overLapping = false;
        exit = false;
        var clones = GameObject.FindGameObjectsWithTag("Spheree");

        foreach (var clone in clones)
        {

            Debug.Log("Gam");

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
        Debug.Log("222222222222222222222222222222222");
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
        //DragHandle._ball.SetActive(true);
        bool oo = false; int o = 0;
        SphereCollider sc;
        int i;
        GameController.check = true;
        float b, c, radius, distance;
        radius = GameController.size;
        distance = 1.95f;
        if (GameController.check == true)
        {
            p = GameController.box+1;
            if (p == 2)
            {
                Game12Over = false;
                radius = 0.575f;
                distance = 2.5f;
            }
            else if (p == 3)
            {
                Game12Over = false;
                radius = 0.55f;
                distance = 2.45f;
            }
            else if (p == 4)
            {
                Game12Over = false;
                radius = 0.515f;
                distance = 2.40f;
            }
            else if (p == 5)
            {
                Game12Over = false;
                radius = 0.475f;
                distance = 2.35f;
            }
            else if (p == 6)
            {
                Game12Over = false;
                radius = 0.45f;
                distance = 2.30f;
            }
            else if (p == 7)
            {
                Game12Over = false;
                radius = 0.415f;
                distance = 2.25f;
            }
            else if (p == 8)
            {
                Game12Over = false;
                radius = 0.4f;
                distance = 2.20f;
            }
            else if (p == 9)
            {
                Game12Over = false;
                radius = 0.375f;
                distance = 2.15f;
            }
            else if (p == 10)
            {
                Game12Over = false;
                radius = 0.35f;
                distance = 2.10f;
            }
            else if (p == 11)
            {
                Game12Over = false;
                radius = 0.315f;
                distance = 2.05f;
            }
            else if (p == 12)
            {
                Game12Over = false;
                radius = 0.3f;
                distance = 2.00f;
            }
            else
            {
                Game12Over = true;
                p = 0;
            }
            GameController.check = false;
        }
        if (Game12Over == false)
        {

            for (i = 0; i < p; i++)
            {
                Debug.Log(i);
                if (i == 0)
                {
                    b = UnityEngine.Random.Range(-0.40000f, 0.40000f);
                    c = UnityEngine.Random.Range(1.800000f, 2.60000f);
                    if (b < -0.40000f || b < 0.40000f)
                    {
                        x1 = b;
                    }
                    z1 = 3.0f;
                    if (c < 1.800000f || c < 2.60000f)
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
                    float xLowerBound = UnityEngine.Random.Range(-1.00000f, -2.0000f);
                    float xUpperBound = UnityEngine.Random.Range(1.00000f, 2.0000f);
                    float yLowerBound = UnityEngine.Random.Range(-1.2000f, 0.10000f);
                    float yUpperBound = UnityEngine.Random.Range(3.30000f, 4.10000f);
                    float[] k = new float[2];
                    k[0] = xLowerBound;
                    k[1] = xUpperBound;
                    float[] p = new float[2];
                    p[0] = xLowerBound;
                    p[1] = xUpperBound;
                    b = k[UnityEngine.Random.Range(0, k.Length)];
                    c = p[UnityEngine.Random.Range(0, p.Length)];
                    if (b < (xLowerBound) || b < (xUpperBound))
                    {
                        xi = b;
                    }
                    zi = 3.0f;
                    if (c < (yLowerBound) || c < (yUpperBound))
                    {
                        yi = c;
                    }

                    var deg = Math.Asin((Mathf.Sqrt((Mathf.Pow((x1), 2)) + (Mathf.Pow((y1), 2)))) / x1);

                    g = Mathf.Sqrt((Mathf.Pow((xi - x0), 2)) + (Mathf.Pow((yi - y0), 2)));
                    var deg1 = Math.Asin(yi / g);  //(Mathf.Sqrt((Mathf.Pow((x1), 2)) + (Mathf.Pow((y1), 2))))
                    gr = Mathf.Sqrt((Mathf.Pow((xi - x1), 2)) + (Mathf.Pow((yi - y1), 2)));
                    var deg2 = Math.Asin(y1 / gr);
                    Debug.Log("G " + g);
                    Debug.Log("Gr " + gr);
                    Debug.Log("Degreeeeeeeeeeeeee1" + deg1);
                    Debug.Log("Degreeeeeeeeeeeeee2" + deg2);
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
                        o++;
                        oo = true;

                        if (o == 1 && oo == true)
                        {
                            Debug.Log("O U T S I D E");
                            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                            sphere = (GameObject)Instantiate(myPrefab, new Vector3(0.0f, 0.0f, 2.5f), Quaternion.identity);
                            sphere.gameObject.tag = "Spheree";
                            sc = sphere.AddComponent<SphereCollider>();
                            sc.radius = radius;
                            sc.isTrigger = true;
                            print("*****************\\\\*********************");
                            Debug.Log(xi + " " + yi);
                            print("******************\\\\********************");
                            // x1rand = x1; yrand = y1;
                            sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(0, 0);
                            oo = false;

                        }


                        if (o == 1 && oo == true)
                        {

                            Debug.Log("O U T S I D E");
                            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                            sphere = (GameObject)Instantiate(myPrefab, new Vector3(2.2f, 2.27f, 3.0f), Quaternion.identity);
                            sphere.gameObject.tag = "Spheree";
                            sc = sphere.AddComponent<SphereCollider>();
                            sc.radius = radius;
                            sc.isTrigger = true;
                            print("*****************\\\\*********************");
                            Debug.Log(xi + " " + yi);
                            print("******************\\\\********************");
                            // x1rand = x1; yrand = y1;
                            sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(2.2f, 2.27f);
                            oo = false;
                        }

                        if (o == 2 && oo == true)
                        {

                            Debug.Log("O U T S I D E");
                            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                            sphere = (GameObject)Instantiate(myPrefab, new Vector3(-2.2f, 2.27f, 3.0f), Quaternion.identity);
                            sphere.gameObject.tag = "Spheree";
                            sc = sphere.AddComponent<SphereCollider>();
                            sc.radius = radius;
                            sc.isTrigger = true;
                            print("*****************\\\\*********************");
                            Debug.Log(xi + " " + yi);
                            print("******************\\\\********************");
                            // x1rand = x1; yrand = y1;
                            sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(-2.2f, 2.27f);
                            oo = false;
                        }
                    }
                }
            }
        }
        levelText.text = "LEVEL: " + GameController.box.ToString();
        //trailNextLevel++;
    }

    public void Game()
    {
        //DragHandle._ball.SetActive(true);
        bool oo = false; int o = 0;
        SphereCollider sc;
        int  i;
        float b, c, radius, distance;
        a = trailNextLevel+1;
        radius = GameController.size;
        distance = 1.95f;
        if ( GameController.check == true)
        {
            p = GameController.box;
        }
        if (a == 2 || p == 2)
        {
            radius = 0.575f;
            distance = 2.5f;
        }
        else if (a == 3 || p == 3)
        {
            radius = 0.55f;
            distance = 2.45f;
        }
        else if (a == 4 || p == 4)
        {
            radius = 0.515f;
            distance = 2.40f;
        }
        else if (a == 5 || p == 5)
        {
            radius = 0.475f;
            distance = 2.35f;
        }
        else if (a == 6 || p == 6)
        {
            radius = 0.45f;
            distance = 2.30f;
        }
        else if (a == 7 || p == 7)
        {
            radius = 0.415f;
            distance = 2.25f;
        }
        else if (a == 8 || p == 8)
        {
            radius = 0.4f;
            distance = 2.20f;
        }
        else if (a == 9 || p == 9 )
        {
            radius = 0.375f;
            distance = 2.15f;
        }
        else if (a == 10|| p == 10)
        {
            radius = 0.35f;
            distance = 2.10f;
        }
        else if (a == 11 || p == 11)
        {
            radius = 0.315f;
            distance = 2.05f;
        }
        else if (a == 12 || p == 12) { 
            radius = 0.3f;
            distance = 2.00f;
        }
        else {
            Game12Over = true;
            a = 0;
        }
        if (Game12Over == false)
        {
            // distance = GameController.distance;
            for (i = 0; i < a; i++)
            {
                Debug.Log(i);
                if (i == 0)
                {

                    b = UnityEngine.Random.Range(-0.40000f, 0.40000f);
                    c = UnityEngine.Random.Range(0.50000f, 4.50000f);
                    if (b < -0.40000f || b < 0.40000f)
                    {
                        x1 = b;
                    }
                    z1 = 3.0f;
                    if (c < 0.50000f || c < 4.5000f)
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
                    b = UnityEngine.Random.Range(-0.40000f - distance, 0.40000f + distance);
                    c = UnityEngine.Random.Range(1.800000f - distance, 2.60000f + distance);
                    if (b < -0.40000f - distance || b < 0.40000f + distance)
                    {
                        xi = b;
                    }
                    zi = 3.0f;
                    if (c < 1.800000f - distance || c < 2.60000f + distance)
                    {
                        yi = c;
                    }

                    g = Mathf.Sqrt((Mathf.Pow((xi - x0), 2)) + (Mathf.Pow((yi - y0), 2)));
                    var deg1 = Math.Asin(yi / g);  //(Mathf.Sqrt((Mathf.Pow((x1), 2)) + (Mathf.Pow((y1), 2))))
                    gr = Mathf.Sqrt((Mathf.Pow((xi - x1), 2)) + (Mathf.Pow((yi - y1), 2)));
                    var deg2 = Math.Asin(y1 / gr);
                    Debug.Log("G " + g);
                    Debug.Log("Gr " + gr);
                    Debug.Log("Degreeeeeeeeeeeeee1" + deg1);
                    Debug.Log("Degreeeeeeeeeeeeee2" + deg2);
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
                        o++;
                        oo = true;
                        
                        if (o == 1 && oo ==true)
                        {
                            Debug.Log("O U T S I D E");
                            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                            sphere = (GameObject)Instantiate(myPrefab, new Vector3(0.0f, 0.0f, 2.5f), Quaternion.identity);
                            sphere.gameObject.tag = "Spheree";
                            sc = sphere.AddComponent<SphereCollider>();
                            sc.radius = radius;
                            sc.isTrigger = true;
                            print("*****************\\\\*********************");
                            Debug.Log(xi + " " + yi);
                            print("******************\\\\********************");
                            // x1rand = x1; yrand = y1;
                            sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(0, 0);
                            oo = false;

                        }


                        if(o == 1  && oo==true)
                        {

                            Debug.Log("O U T S I D E");
                            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                            sphere = (GameObject)Instantiate(myPrefab, new Vector3(2.2f, 2.27f, 3.0f), Quaternion.identity);
                            sphere.gameObject.tag = "Spheree";
                            sc = sphere.AddComponent<SphereCollider>();
                            sc.radius = radius;
                            sc.isTrigger = true;
                            print("*****************\\\\*********************");
                            Debug.Log(xi + " " + yi);
                            print("******************\\\\********************");
                            // x1rand = x1; yrand = y1;
                            sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(2.2f, 2.27f);
                            oo = false;
                        }

                        if(o == 2  && oo== true)
                        {

                            Debug.Log("O U T S I D E");
                            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                            sphere = (GameObject)Instantiate(myPrefab, new Vector3(-2.2f, 2.27f, 3.0f), Quaternion.identity);
                            sphere.gameObject.tag = "Spheree";
                            sc = sphere.AddComponent<SphereCollider>();
                            sc.radius = radius;
                            sc.isTrigger = true;
                            print("*****************\\\\*********************");
                            Debug.Log(xi + " " + yi);
                            print("******************\\\\********************");
                            // x1rand = x1; yrand = y1;
                            sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(-2.2f, 2.27f);
                            oo = false;
                        }

                    }
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
       // DragHandle._ball.SetActive(true);
        SphereCollider sc;
        int i;
        float b, c, radius, distance;
        radius = GameController.size;
        distance = 1.95f;
        a = trailNextLevel;
        Debug.Log(a);
        if (GameController.check == true)
        {
            p = GameController.box;
        }
        if (a == 2 || p == 2)
        {
            radius = 0.575f;
            distance = 2.5f;
        }
        else if (a == 3 || p == 3)
        {
            radius = 0.55f;
            distance = 2.45f;
        }
        else if (a == 4 || p == 4)
        {
            radius = 0.515f;
            distance = 2.40f;
        }
        else if (a == 5 || p == 5)
        {
            radius = 0.475f;
            distance = 2.35f;
        }
        else if (a == 6 || p == 6)
        {
            radius = 0.45f;
            distance = 2.30f;
        }
        else if (a == 7 || p == 7)
        {
            radius = 0.415f;
            distance = 2.25f;
        }
        else if (a == 8 || p == 8)
        {
            radius = 0.4f;
            distance = 2.20f;
        }
        else if (a == 9 || p == 9)
        {
            radius = 0.375f;
            distance = 2.15f;
        }
        else if (a == 10 || p == 10)
        {
            radius = 0.35f;
            distance = 2.10f;
        }
        else if (a == 11 || p == 11)
        {
            radius = 0.315f;
            distance = 2.05f;
        }
        else if (a == 12 || p == 12)
        {
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
            for (i = 0; i < a; i++)
            {
                Debug.Log(i);
                if (i == 0)
                {
                    b = UnityEngine.Random.Range(-1.5000f, 1.50000f);
                    c = UnityEngine.Random.Range(0.0000f, 4.00000f);
                    if (b < -1.5000f || b < 1.50000f)
                    {
                        x1 = b;
                    }
                    z1 = 3.0f;
                    if (c < 0.00000f || c < 4.000000f)
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
                    zi = 3.0f;
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
                        sphere = (GameObject)Instantiate(myPrefab, new Vector3(0.0f, 0.0f, 2.5f), Quaternion.identity);
                        sphere.gameObject.tag = "Spheree";
                        sc = sphere.AddComponent<SphereCollider>();
                        sc.radius = radius;
                        sc.isTrigger = true;
                        print("*****************\\\\*********************");
                        Debug.Log(xi + " " + yi);
                        print("******************\\\\********************");
                        // x1rand = x1; yrand = y1;
                        sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(0, 0);

                    }
                }
            }
        }
     

    }


    public void GameTestLevel()   //Game1
    {
        SphereCollider sc;
        int i;
        Vector2[] circles;
        Vector2[] prevCircle;
        GameController.check = true;
        float b, c, radius, distance;
        radius = GameController.size;
        distance = 1.0f;
        if (GameController.check == true)
        {
            p = GameController.box + 1;
            if (p == 2)
            {
                Game12Over = false;
                radius = 0.575f;
                distance = 2.5f;
            }
            else if (p == 3)
            {
                Game12Over = false;
                radius = 0.55f;
                distance = 2.45f;
            }
            else if (p == 4)
            {
                Game12Over = false;
                radius = 0.515f;
                distance = 2.40f;
            }
            else if (p == 5)
            {
                Game12Over = false;
                radius = 0.475f;
                distance = 2.35f;
            }
            else if (p == 6)
            {
                Game12Over = false;
                radius = 0.45f;
                distance = 2.30f;
            }
            else if (p == 7)
            {
                Game12Over = false;
                radius = 0.415f;
                distance = 2.25f;
            }
            else if (p == 8)
            {
                Game12Over = false;
                radius = 0.4f;
                distance = 2.20f;
            }
            else if (p == 9)
            {
                Game12Over = false;
                radius = 0.375f;
                distance = 2.15f;
            }
            else if (p == 10)
            {
                Game12Over = false;
                radius = 0.35f;
                distance = 2.10f;
            }
            else if (p == 11)
            {
                Game12Over = false;
                radius = 0.315f;
                distance = 2.05f;
            }
            else if (p == 12)
            {
                Game12Over = false;
                radius = 0.3f;
                distance = 2.00f;
            }
            else
            {
                Game12Over = true;
                p = 0;
            }
            GameController.check = false;
        }
        if (Game12Over == false) 
        {
            newX = new float[5];
            newY = new float[5];
            Debug.Log( (float)Math.Sqrt(UnityEngine.Random.value * 6));
            circles = new Vector2[5];
            prevCircle = new Vector2[5];
            newZ = 3.0f;
            i = 0;
            while(i<5)
            {
                angle = UnityEngine.Random.value * (float)Math.PI * 2;
                r = (float)Math.Sqrt(UnityEngine.Random.value * 6);
                circles[i].x = originX + (r * (float)Math.Cos(angle));
                circles[i].y = originY + (r * (float)Math.Sin(angle));
                prevCircle = circles;
                overLapping = false;
                for (int j = 0; j < prevCircle.Length; j++)
                {
                    exit = false;
                    for (int l = 0; l < circles.Length; l++)
                    {
                        var d = Mathf.Sqrt((Mathf.Pow((prevCircle[j].x - circles[l].x), 2)) + (Mathf.Pow((prevCircle[j].y - circles[l].y), 2)));
                        if (exit == false)
                        {
                            if (d > distance)
                            {
                                overLapping = true;
                                Debug.Log(overLapping);
                                Debug.Log("Loooookk  on it" + j);
                                angle = UnityEngine.Random.value * (float)Math.PI * 2;
                                r = (float)Math.Sqrt(UnityEngine.Random.value * UnityEngine.Random.Range(1, 6));
                                circles[l].x = originX + (r * (float)Math.Cos(angle));
                                circles[l].y = originY + (r * (float)Math.Sin(angle));
                                //prevCircle = circles;
                                myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                                sphere = (GameObject)Instantiate(myPrefab, new Vector3(circles[l].x, circles[l].y, newZ), Quaternion.identity);
                                sphere.gameObject.tag = "Spheree";
                                sc = sphere.AddComponent<SphereCollider>();
                                sc.radius = radius;
                                sc.isTrigger = true;
                                sphere.transform.position = new Vector3(circles[l].x, circles[l].y, newZ);
                                sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(circles[l].x, circles[l].y);
                                exit = true;
                            }
                        }
                    }
                   /* else
                    {

                        myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                        sphere = (GameObject)Instantiate(myPrefab, new Vector3(circles[j].x, circles[j].y, newZ), Quaternion.identity);
                        sphere.gameObject.tag = "Spheree";
                        sc = sphere.AddComponent<SphereCollider>();
                        sc.radius = radius;
                        sc.isTrigger = true;
                        sphere.transform.position = new Vector3(circles[j].x, circles[j].y, newZ);
                        sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(circles[j].x, circles[j].y);

                    }*/
                    i++;
                }
               
            }
        }
    }

}
