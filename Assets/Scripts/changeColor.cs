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
    }

    public void ButtonTransitionColors() {
		GetComponent<Image>().color = new Color(Random.Range(0F, 1F), Random.Range(0F, 1F), Random.Range(0F, 1F));
    }

}
