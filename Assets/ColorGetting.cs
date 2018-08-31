using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorGetting : MonoBehaviour {
    Color[] Data;
    public Image ImageRenderer;

    public int Width { get { return ImageRenderer.sprite.texture.width; } }
    public int Height { get { return ImageRenderer.sprite.texture.height; } }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
