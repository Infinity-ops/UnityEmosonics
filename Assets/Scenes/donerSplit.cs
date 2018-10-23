using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donerSplit : MonoBehaviour {
    public GameObject cc;
    public GameObject sphere;
    public GameObject myPrefab;
    float radius, x1, y1, z1, x0 = 0, y0 = 2.2f, g, gr, xi, yi, zi,angle, r;
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
    int n_angles; //no.of angles
    int ran; //for random
    Color[] Data;
    public Sprite ImageSprite;
    public int Width { get { return ImageSprite.texture.width; } }
    public int Height { get { return ImageSprite.texture.height; } }
    int a;
 
    List<Vector2> positions = new List<Vector2>(5);
    //List<List> posit = new List<List>();
    //private RectTransform circle;
    // Use this for initialization
    void Start() {
        a = 2;
        r = 0.5f;
        n_angles = 5;
       
    }
    /* public Color getColorByNormalizedPosition(float X, float Y)
    {
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
    */
    // Update is called once per frame
    void Update () {
        
        if (a == 2) //level selection
        {
            for (int j = 1; j < 5; j++)
            {
                for (int i = 0; i < n_angles; i++)
                {
                    
                    if (j == 1)
                    {
                        posSPhere1 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere1[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere1[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.0f;
                        pos1.Add(posSPhere1[i]);
                       // myAL.Add();
                        Debug.Log("GGGGGGGGGGGGGGGGGGGGGgggggggggg" + posSPhere1[i]);


                    }
                    if (j == 2)
                    {
                        posSPhere2 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere2[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere2[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.0f;
                        pos2.Add(posSPhere2[i]);
                    }
                    if (j == 3)
                    {
                        posSPhere3 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere3[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere3[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.0f;
                        pos3.Add(posSPhere3[i]);
                    }
                    if (j == 4)
                    {
                        posSPhere4 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere4[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere4[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.0f;
                        pos4.Add(posSPhere4[i]);
                    }
                    if (j == 5)
                    {
                        posSPhere5 = new Vector2[n_angles];
                        angle = i * (360 / n_angles);
                        angle = angle * Mathf.Deg2Rad;
                        posSPhere5[i].x = x0 + r * Mathf.Cos(angle);
                        posSPhere5[i].y = y0 + r * Mathf.Sin(angle);
                        z1 = 3.0f;
                        pos5.Add(posSPhere5[i]);
                    }  
                }
                r += 0.5f;
                n_angles += 5;
               // positions.Add(pos1);
            }
            ran = Random.Range(1, posSPhere3.Length);
            testRan= pos3[ran];
            x1 = testRan.x;
            y1 = testRan.y;
            Debug.Log("GGGGGGGGGGGGGGGGGGGG  " + x1 +"  "+ y1 +"              "+ran);    
            radius = 0.5f;
            SphereCollider sc;
            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
            sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1,y1,z1), Quaternion.identity);
            sphere.gameObject.tag = "Spheree";
            sc = sphere.AddComponent<SphereCollider>();
            sc.radius = radius;
            sc.isTrigger = true;
            sphere.transform.position = new Vector3(x1,y1, z1);
            print("**************************************");
            Debug.Log(x1 + " * *" + y1);
            print("**************************************");
            //xrand = x1; yrand = y1;
            // sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
            //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
            a++;

        }
        if (a == 3) {
            ran = Random.Range(1, posSPhere5.Length);
            testRan = pos5[ran];
            x1 = testRan.x;
            y1 = testRan.y;
            Debug.Log("GGGGGGGGGGGGGGGGGGGG  " + x1 + "  " + y1 + "              " + ran);
            radius = 0.5f;
            SphereCollider sc;
            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
            sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
            sphere.gameObject.tag = "Spheree";
            sc = sphere.AddComponent<SphereCollider>();
            sc.radius = radius;
            sc.isTrigger = true;
            sphere.transform.position = new Vector3(x1, y1, z1);
            print("**************************************");
            Debug.Log(x1 + " * *" + y1);
            print("**************************************");
            //xrand = x1; yrand = y1;
            // sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
            //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
            a++;
        }
        if (a == 4) {
            ran = Random.Range(1, pos1.Count);
            testRan = pos1[ran];
            x1 = testRan.x;
            y1 = testRan.y;
            Debug.Log("GGGGGGGGGGGGGGGGGGGG  " + x1 + "  " + y1 + "              " + ran);
            radius = 0.5f;
            SphereCollider sc;
            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
            sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
            sphere.gameObject.tag = "Spheree";
            sc = sphere.AddComponent<SphereCollider>();
            sc.radius = radius;
            sc.isTrigger = true;
            sphere.transform.position = new Vector3(x1, y1, z1);
            print("**************************************");
            Debug.Log(x1 + " * *" + y1);
            print("**************************************");
            //xrand = x1; yrand = y1;
            // sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
            //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
            a++;
            pos1.Remove(pos1[ran]);
        }
        if (a == 5)
        {
            ran = Random.Range(1, pos1.Count);
            testRan = pos1[ran];
            x1 = testRan.x;
            y1 = testRan.y;
            Debug.Log("GGGGGGGGGGGGGGGGGGGG  " + x1 + "  " + y1 + "              " + ran);
            radius = 0.5f;
            SphereCollider sc;
            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
            sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
            sphere.gameObject.tag = "Spheree";
            sc = sphere.AddComponent<SphereCollider>();
            sc.radius = radius;
            sc.isTrigger = true;
            sphere.transform.position = new Vector3(x1, y1, z1);
            print("**************************************");
            Debug.Log(x1 + " * *" + y1);
            print("**************************************");
            //xrand = x1; yrand = y1;
            // sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
            //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
            a++;
            pos1.Remove(pos1[ran]);
        }
        if (a == 6)
        {
            ran = Random.Range(1, pos1.Count);
            testRan = pos1[ran];
            x1 = testRan.x;
            y1 = testRan.y;
            Debug.Log("GGGGGGGGGGGGGGGGGGGG  " + x1 + "  " + y1 + "              " + ran);
            radius = 0.5f;
            SphereCollider sc;
            myPrefab.transform.localScale = new Vector3(radius, radius, radius);
            sphere = (GameObject)Instantiate(myPrefab, new Vector3(x1, y1, z1), Quaternion.identity);
            sphere.gameObject.tag = "Spheree";
            sc = sphere.AddComponent<SphereCollider>();
            sc.radius = radius;
            sc.isTrigger = true;
            sphere.transform.position = new Vector3(x1, y1, z1);
            print("**************************************");
            Debug.Log(x1 + " * *" + y1);
            print("**************************************");
            //xrand = x1; yrand = y1;
            // sphere.GetComponent<Renderer>().material.color = getColorByNormalizedPosition(x1, y1);
            //Debug.Log(getColorByNormalizedPosition(x1, y1)); 
            a++;
            pos1.Remove(pos1[ran]);
        }
    }
}
