using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSlide : MonoBehaviour
{

    public static Text box1;
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
    bool check = false;
    bool check1 = false;
    bool check2 = false;
    int i = 0;
    int endcount = 0;
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
        if (count > 1 || count < 0)
        {
            i = endcount - 12 + 1;
            box1.text = "Level " + (12 + i); 
            box2.text = "Level " + (12 + i); i++;
            box3.text = "Level " + (12 + i); i++;
            box4.text = "Level " + (12 + i); i++;
            box4.text = "Level " + (12 + i); i++;
            box5.text = "Level " + (12 + i); i++;
            box6.text = "Level " + (12 + i); i++;
            box7.text = "Level " + (12 + i); i++;
            box8.text = "Level " + (12 + i); i++;
            box9.text = "Level " + (12 + i); i++;
            box11.text = "Level " + (12 + i); i++;
            box12.text = "Level " + (12 + i); i++;
            endcount = i + 11;
           
        }
        if (count == 0)
        {
            i = endcount - 11;
            box1.text = "Level " + (12 + i); 
            box2.text = "Level " + (12 + i); i++;
            box3.text = "Level " + (12 + i); i++;
            box4.text = "Level " + (12 + i); i++;
            box4.text = "Level " + (12 + i); i++;
            box5.text = "Level " + (12 + i); i++;
            box6.text = "Level " + (12 + i); i++;
            box7.text = "Level " + (12 + i); i++;
            box8.text = "Level " + (12 + i); i++;
            box9.text = "Level " + (12 + i); i++;
            box11.text = "Level " + (12 + i); i++;
            box12.text = "Level " + (12 + i); i++;
            endcount = i + 11;
            
        }
        if (count == 1)
        {
            
            if (endcount == 0)
            {
                i = endcount + 1;
                box1.text = "Level " + (12 + i); 
                box2.text = "Level " + (12 + i); i++;
                box3.text = "Level " + (12 + i); i++;
                box4.text = "Level " + (12 + i); i++;
                box4.text = "Level " + (12 + i); i++;
                box5.text = "Level " + (12 + i); i++;
                box6.text = "Level " + (12 + i); i++;
                box7.text = "Level " + (12 + i); i++;
                box8.text = "Level " + (12 + i); i++;
                box9.text = "Level " + (12 + i); i++;
                box11.text = "Level " + (12 + i); i++;
                box12.text = "Level " + (12 + i); i++;
                endcount = i + 11;
               
            }
            else
            {
                i = endcount - 12 + 1;
                box1.text = "Level " + (12 + i); 
                box2.text = "Level " + (12 + i); i++;
                box3.text = "Level " + (12 + i); i++;
                box4.text = "Level " + (12 + i); i++;
                box4.text = "Level " + (12 + i); i++;
                box5.text = "Level " + (12 + i); i++;
                box6.text = "Level " + (12 + i); i++;
                box7.text = "Level " + (12 + i); i++;
                box8.text = "Level " + (12 + i); i++;
                box9.text = "Level " + (12 + i); i++;
                box11.text = "Level " + (12 + i); i++;
                box12.text = "Level " + (12 + i); i++;
                endcount = i + 11;
                
            }
        }  
    }

    /**
     * left click is for sliding to next previous page
     */

    public void Left_click()
    {
        count--;
        
        if (count < -1 || count > 0)
        {
            i = endcount -12+1;
            box1.text = "Level " + (i - 12); 
            box2.text = "Level " + (i - 12); i++;
            box3.text = "Level " + (i - 12); i++;
            box4.text = "Level " + (i - 12); i++;
            box4.text = "Level " + (i - 12); i++;
            box5.text = "Level " + (i - 12); i++;
            box6.text = "Level " + (i - 12); i++;
            box7.text = "Level " + (i - 12); i++;
            box8.text = "Level " + (i - 12); i++;
            box9.text = "Level " + (i - 12); i++;
            box11.text = "Level " + (i - 12); i++;
            box12.text = "Level " + (i - 12); i++;
            endcount = (i - 13);
          
        }
        if (count == 0)
        {
            i = endcount - 11;
            box1.text = "Level " + (i - 12); 
            box2.text = "Level " + (i - 12); i++;
            box3.text = "Level " + (i - 12); i++;
            box4.text = "Level " + (i - 12); i++;
            box4.text = "Level " + (i - 12); i++;
            box5.text = "Level " + (i - 12); i++;
            box6.text = "Level " + (i - 12); i++;
            box7.text = "Level " + (i - 12); i++;
            box8.text = "Level " + (i - 12); i++;
            box9.text = "Level " + (i - 12); i++;
            box11.text = "Level " + (i - 12); i++;
            box12.text = "Level " + (i - 12); i++;
            endcount = (i - 13);
           
        }
        if (count == -1)
        {
            if (endcount == 0)
            {
                i = endcount + 1;
                box1.text = "Level " + (i - 12); 
                box2.text = "Level " + (i - 12); i++;
                box3.text = "Level " + (i - 12); i++;
                box4.text = "Level " + (i - 12); i++;
                box4.text = "Level " + (i - 12); i++;
                box5.text = "Level " + (i - 12); i++;
                box6.text = "Level " + (i - 12); i++;
                box7.text = "Level " + (i - 12); i++;
                box8.text = "Level " + (i - 12); i++;
                box9.text = "Level " + (i - 12); i++;
                box11.text = "Level " + (i - 12); i++;
                box12.text = "Level " + (i - 12); i++;
                endcount = (i - 13);
                
            }
            else
            {
                i = endcount - 12 + 1;
                box1.text = "Level " + (i - 12); 
                box2.text = "Level " + (i - 12); i++;
                box3.text = "Level " + (i - 12); i++;
                box4.text = "Level " + (i - 12); i++;
                box4.text = "Level " + (i - 12); i++;
                box5.text = "Level " + (i - 12); i++;
                box6.text = "Level " + (i - 12); i++;
                box7.text = "Level " + (i - 12); i++;
                box8.text = "Level " + (i - 12); i++;
                box9.text = "Level " + (i - 12); i++;
                box11.text = "Level " + (i - 12); i++;
                box12.text = "Level " + (i - 12); i++;
                endcount = (i - 13);
                
            }
            
        }               

    }
}
