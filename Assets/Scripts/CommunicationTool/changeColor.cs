using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour {

    private Image image;
 
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
        if(this.name.EndsWith("1")) {
            image.color = GameControl.control.favorite1Color;
        }
        if(this.name.EndsWith("2")) {
            image.color = GameControl.control.favorite2Color;
        }
        if(this.name.EndsWith("3")) {
            image.color = GameControl.control.favorite3Color;
        }
        if(this.name.EndsWith("4")) {
            image.color = GameControl.control.favorite4Color;
        }
    }

    public void ButtonRandomColors() {
        Color color = new Color(Random.Range(0F, 1F), Random.Range(0F, 1F), Random.Range(0F, 1F));
		GetComponent<Image>().color = color;
        if(this.name.EndsWith("1")) {
            GameControl.control.favorite1Color = color;
            GameControl.control.favorite1Pos = GameControl.control.crosshairPosition;
            GameControl.control.favorite1Sound = GameControl.control.soundPosition;
        }
        if(this.name.EndsWith("2")) {
            GameControl.control.favorite2Color = color;
            GameControl.control.favorite2Pos = GameControl.control.crosshairPosition;
            GameControl.control.favorite2Sound = GameControl.control.soundPosition;
        }
        if(this.name.EndsWith("3")) {
            GameControl.control.favorite3Color = color;
            GameControl.control.favorite3Pos = GameControl.control.crosshairPosition;
            GameControl.control.favorite3Sound = GameControl.control.soundPosition;
        }
        if(this.name.EndsWith("4")) {
            GameControl.control.favorite4Color = color;
            GameControl.control.favorite4Pos = GameControl.control.crosshairPosition;
            GameControl.control.favorite4Sound = GameControl.control.soundPosition;
        }
    }

    public void ButtonChangeColor() {
        
    }

}
