using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour {

    private Image image;

	public GameObject colorWheel;
 
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
        if(this.name.EndsWith("1")) {
            image.color = GameControl.control.favorite1_color;
        }
        if(this.name.EndsWith("2")) {
            image.color = GameControl.control.favorite2_color;
        }
        if(this.name.EndsWith("3")) {
            image.color = GameControl.control.favorite3_color;
        }
        if(this.name.EndsWith("4")) {
            image.color = GameControl.control.favorite4_color;
        }
    }

    public void ButtonTransitionColors() {
        Color color = new Color(Random.Range(0F, 1F), Random.Range(0F, 1F), Random.Range(0F, 1F));
		GetComponent<Image>().color = color;
        if(this.name.EndsWith("1")) {
            GameControl.control.favorite1_color = color;
        }
        if(this.name.EndsWith("2")) {
            GameControl.control.favorite2_color = color;
        }
        if(this.name.EndsWith("3")) {
            GameControl.control.favorite3_color = color;
        }
        if(this.name.EndsWith("4")) {
            GameControl.control.favorite4_color = color;
        }
    }

    public void ButtonChangeColor() {

    }

}
