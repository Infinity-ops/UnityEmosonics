using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestLevelSlide : MonoBehaviour
{
    /** text box for all buttons in grid layout */
    public Text box1;
    public Text box2;
    public Text box3;
    public Text box4;
    public Text box5;
    public Text box6;
    public Text box7;
    public Text box8;
    public Text box9;
    public Text box10;
    public Text box11;
    public Text box12;
    public static int n1=1, n2=2, n3=3, n4=4, n5=5, n6=6, n7=7, n8=8, n9=9, n10=10, n11=11, n12=12; 
    bool check = false;
    bool check1 = false;
    bool check2 = false;
    int endcount = 0;
    int i = 0;
    int count = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    /**
     * Right click is for sliding to next level page
     */
    public void Right_click()
    {
        count++;
        Debug.Log("count " + count + "endcount " + endcount);
        if (count > 1 || count < 0)
        {
            Debug.Log(endcount);
            i = endcount - 12 +1;
            box1.text = "Level " + (12 + i); n1= 12 + i;  i++;
            box2.text = "Level " + (12 + i); n2 = 12 + i; i++;
            box3.text = "Level " + (12 + i); n3 = 12 + i; i++;
            box4.text = "Level " + (12 + i); n4 = 12 + i; i++;
            box5.text = "Level " + (12 + i); n5 = 12 + i; i++;
            box6.text = "Level " + (12 + i); n6 = 12 + i; i++;
            box7.text = "Level " + (12 + i); n7 = 12 + i; i++;
            box8.text = "Level " + (12 + i); n8 = 12 + i; i++;
            box9.text = "Level " + (12 + i); n9 = 12 + i; i++;
            box10.text = "Level " + (12 + i); n10 = 12 + i; i++;
            box11.text = "Level " + (12 + i); n11 = 12 + i; i++;
            box12.text = "Level " + (12 + i); n12 = 12 + i;
            endcount = i + 12;
            Debug.Log(endcount);
        }
        if (count == 0)
        {
            Debug.Log(endcount);
            i = endcount - 11;
            box1.text = "Level " + (12 + i); n1 = 12 + i; i++;
            box2.text = "Level " + (12 + i); n2 = 12 + i; i++;
            box3.text = "Level " + (12 + i); n3 = 12 + i; i++;
            box4.text = "Level " + (12 + i); n4 = 12 + i; i++;
            box5.text = "Level " + (12 + i); n5 = 12 + i; i++;
            box6.text = "Level " + (12 + i); n6 = 12 + i; i++;
            box7.text = "Level " + (12 + i); n7 = 12 + i; i++;
            box8.text = "Level " + (12 + i); n8 = 12 + i; i++;
            box9.text = "Level " + (12 + i); n9 = 12 + i; i++;
            box10.text = "Level " + (12 + i); n10 = 12 + i; i++;
            box11.text = "Level " + (12 + i); n11 = 12 + i; i++;
            box12.text = "Level " + (12 + i); n12 = 12 + i; endcount = i + 12;
            Debug.Log(endcount);
        }
        if (count == 1)
        {
            Debug.Log("Right one");
            if (endcount == 0)
            {
                Debug.Log(endcount);
                i = endcount + 1;
                box1.text = "Level " + (12 + i); n1 = 12 + i; i++;
                box2.text = "Level " + (12 + i); n2 = 12 + i; i++;
                box3.text = "Level " + (12 + i); n3 = 12 + i; i++;
                box4.text = "Level " + (12 + i); n4 = 12 + i; i++;
                box5.text = "Level " + (12 + i); n5 = 12 + i; i++;
                box6.text = "Level " + (12 + i); n6 = 12 + i; i++;
                box7.text = "Level " + (12 + i); n7 = 12 + i; i++;
                box8.text = "Level " + (12 + i); n8 = 12 + i; i++;
                box9.text = "Level " + (12 + i); n9 = 12 + i; i++;
                box10.text = "Level " + (12 + i); n10 = 12 + i; i++;
                box11.text = "Level " + (12 + i); n11 = 12 + i; i++;
                box12.text = "Level " + (12 + i); n12 = 12 + i;
                endcount = i + 12;
                Debug.Log(endcount);
            }
            else
            {
                Debug.Log(endcount);
                i = endcount - 12 + 1;
                box1.text = "Level " + (12 + i); n1 = 12 + i; i++;
                box2.text = "Level " + (12 + i); n2 = 12 + i; i++;
                box3.text = "Level " + (12 + i); n3 = 12 + i; i++;
                box4.text = "Level " + (12 + i); n4 = 12 + i; i++;
                box5.text = "Level " + (12 + i); n5 = 12 + i; i++;
                box6.text = "Level " + (12 + i); n6 = 12 + i; i++;
                box7.text = "Level " + (12 + i); n7 = 12 + i; i++;
                box8.text = "Level " + (12 + i); n8 = 12 + i; i++;
                box9.text = "Level " + (12 + i); n9 = 12 + i; i++;
                box10.text = "Level " + (12 + i); n10 = 12 + i; i++;
                box11.text = "Level " + (12 + i); n11 = 12 + i; i++;
                box12.text = "Level " + (12 + i); n12 = 12 + i;
                endcount = i + 12;
                Debug.Log(endcount);
            }
        }
    }
    /**
     * Left click is for sliding to previous level page
     */
    public void Left_click()
    {
        count--;
        Debug.Log("count " + count + "endcount " + endcount);
        if (count < -1 || count > 0)
        {
            if(endcount > 0)
                {
                Debug.Log(endcount);
                i = endcount - 13 +2;
                box1.text = "Level " + (i - 12); n1 = i-12; i++;
                box2.text = "Level " + (i - 12); n2 = i - 12; i++;
                box3.text = "Level " + (i - 12); n3 = i - 12; i++;
                box4.text = "Level " + (i - 12); n4 = i - 12; i++;
                box5.text = "Level " + (i - 12); n5 = i - 12; i++;
                box6.text = "Level " + (i - 12); n6 = i - 12; i++;
                box7.text = "Level " + (i - 12); n7 = i - 12; i++;
                box8.text = "Level " + (i - 12); n8 = i - 12; i++;
                box9.text = "Level " + (i - 12); n9 = i - 12; i++;
                box10.text = "Level " + (i - 12); n10 = i - 12; i++;
                box11.text = "Level " + (i - 12); n11 = i - 12; i++;
                box12.text = "Level " + (i - 12); n12 = i - 12;
                endcount = (i - 12);
                Debug.Log(endcount);

            }
           
        }
        if (count == 0)
        {
            Debug.Log(endcount);
            i = endcount - 12 +1;
            box1.text = "Level " + (i - 12); n1 = i - 12; i++;
            box2.text = "Level " + (i - 12); n2 = i - 12; i++;
            box3.text = "Level " + (i - 12); n3 = i - 12; i++;
            box4.text = "Level " + (i - 12); n4 = i - 12; i++;
            box5.text = "Level " + (i - 12); n5 = i - 12; i++;
            box6.text = "Level " + (i - 12); n6 = i - 12; i++;
            box7.text = "Level " + (i - 12); n7 = i - 12; i++;
            box8.text = "Level " + (i - 12); n8 = i - 12; i++;
            box9.text = "Level " + (i - 12); n9 = i - 12; i++;
            box10.text = "Level " + (i - 12); n10 = i - 12; i++;
            box11.text = "Level " + (i - 12); n11 = i - 12; i++;
            box12.text = "Level " + (i - 12); n12 = i - 12;
            endcount = (i - 12);
            Debug.Log(endcount);
        }
        if (count == -1)
        {
            if (endcount == 0)
            {
                Debug.Log(endcount);
                i = endcount + 1;
                box1.text = "Level " + (i - 12); n1 = i - 12; i++;
                box2.text = "Level " + (i - 12); n2 = i - 12; i++;
                box3.text = "Level " + (i - 12); n3 = i - 12; i++;
                box4.text = "Level " + (i - 12); n4 = i - 12; i++;
                box5.text = "Level " + (i - 12); n5 = i - 12; i++;
                box6.text = "Level " + (i - 12); n6 = i - 12; i++;
                box7.text = "Level " + (i - 12); n7 = i - 12; i++;
                box8.text = "Level " + (i - 12); n8 = i - 12; i++;
                box9.text = "Level " + (i - 12); n9 = i - 12; i++;
                box10.text = "Level " + (i - 12); n10 = i - 12; i++;
                box11.text = "Level " + (i - 12); n11 = i - 12; i++;
                box12.text = "Level " + (i - 12); n12 = i - 12;
                endcount = (i - 12);
                Debug.Log(endcount);
            }
            else
            {
                Debug.Log(endcount);
                i = endcount - 12 + 1;
                box1.text = "Level " + (i - 12); n1 = i - 12; i++;
                box2.text = "Level " + (i - 12); n2 = i - 12; i++;
                box3.text = "Level " + (i - 12); n3 = i - 12; i++;
                box4.text = "Level " + (i - 12); n4 = i - 12; i++;
                box5.text = "Level " + (i - 12); n5 = i - 12; i++;
                box6.text = "Level " + (i - 12); n6 = i - 12; i++;
                box7.text = "Level " + (i - 12); n7 = i - 12; i++;
                box8.text = "Level " + (i - 12); n8 = i - 12; i++;
                box9.text = "Level " + (i - 12); n9 = i - 12; i++;
                box10.text = "Level " + (i - 12); n10 = i - 12; i++;
                box11.text = "Level " + (i - 12); n11 = i - 12; i++;
                box12.text = "Level " + (i - 12); n12 = i - 12;
                endcount = (i - 12);
                Debug.Log(endcount);
            }

        }

    }
}
