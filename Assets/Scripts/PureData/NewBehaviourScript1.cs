using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Magicolo;


public class NewBehaviourScript1 : MonoBehaviour
{
    float btn_width, btn_height;
    float field_width, field_height;


    // Use this for initialization
    void Start()
    {
        //Define button width and height
        btn_width = 100;
        btn_height = 50;
        field_width = 100;
        field_height = 25;
        // Opening the patch will connect it up to the DSP
        PureData.OpenPatch("abstract");
    }

    void OnGUI()
    {

        
        //string field_duration = GUI.TextField(new Rect(100, 100, btn_width, btn_height), "Duration");
        /*  
        if (GUI.Button(new Rect(50,50,btn_width,btn_height),"Send Message"))
        {
            PureData.SendMessage("#touch", "abstract", 1.0, 0.5, 0.2, -30, 56, 12, 0.3, 3, 0.2, 0.5, 1.9);
            PureData.SendMessage("#touch", "aTrigger", "bang");
        } */
    }
}