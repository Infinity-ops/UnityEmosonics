using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Duplicator : MonoBehaviour {
    public Text gameStatus1;
    public GameObject myPrefab;
    public GameObject playButton;
    public GameObject goToNextLevel;
    public GameObject playGainButton;
    public GameObject backButton;
    public static float xrand, yrand; //For RandomSound
    public static int a;
    public GameObject cc;
    public static GameObject sphere;
    private RectTransform circle;
    float radius, x1, y1, z1, x0 = 0, y0 = 2.0f, g, gr,xi, yi, zi;
    Color[] Data;
    public Sprite ImageSprite;
    public int Width { get { return ImageSprite.texture.width; } }
    public int Height { get { return ImageSprite.texture.height; } }
    // Use this for initialization
    public GameObject hitter; // sphere on catapult
    public GameObject panel;
    //public Button btn;
    public static bool realAttemptBall1;
    void Start () {
        // btn.GetComponent<Button>();
        playGainButton.SetActive(false);
        goToNextLevel.SetActive(false);
        playButton.SetActive(true);
        Vector2 center;
        
        center = cc.GetComponent<Renderer>().bounds.center; 
        Debug.Log(center);
        g= 0.0f;
        circle = cc.GetComponent<RectTransform>();
        Data = ImageSprite.texture.GetPixels();
    }
     public void TaskOnClick1() {
        gameStatus1.enabled = false;
        realAttemptBall1 = true;
        GameController.box = GameController.box +1;
        GameCount.scoreValue = 0;
        LivesCount.livesValue = 3;
        Triggertest.cloneDesCount = 0;

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
        panel.SetActive(false);
        hitter.SetActive(true);
        playButton.SetActive(false);
        playGainButton.SetActive(false);
        backButton.SetActive(false);
        SphereCollider sc;
        int i;
        float b, c, radius, distance;
        a = GameController.box + 1;
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
                z1 = 3.2f;
                if (c < 0.00000f || c < 3.5000f)
                {
                    y1 = c;
                }
                myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
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
                b = UnityEngine.Random.Range(-2.5000f, 2.50000f);
                c = UnityEngine.Random.Range(-0.50000f, 4.50000f);
                if (b < -2.5000f || b < 2.50000f)
                {
                    xi = b;
                }
                zi = 3.2f;
                if (c < -0.50000f || c < 4.50000f)
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
        
      panel.SetActive(false);
        hitter.SetActive(true);
        
        SphereCollider sc;
        int  i;
        float b, c, radius,distance;
        a = GameController.box + 1;
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
                z1 = 3.2f;
                if (c < 0.00000f || c < 3.5000f)
                {
                    y1 = c;
                }
                myPrefab.transform.localScale = new Vector3(radius, radius, radius);
                sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
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
            if (i>0)
            {
              
                b = UnityEngine.Random.Range(-2.5000f, 2.50000f);
                c = UnityEngine.Random.Range(-0.50000f, 4.50000f);
                if (b < -2.5000f || b < 2.50000f)
                {
                    xi = b;
                }
                zi = 3.2f;
                if (c < -0.50000f || c < 4.50000f)
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
    // Update is called once per frame
    void Update () {
      //  btn.onClick.AddListener(TaskOnClick);
    }
}
