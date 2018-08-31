using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanging : MonoBehaviour
{
    Color[] Data;
    public Sprite ImageSprite;

    public int Width { get { return ImageSprite.texture.width; } }
    public int Height { get { return ImageSprite.texture.height; } }
    // Use this for initialization
    void Start()
    {
        Data = ImageSprite.texture.GetPixels();
        
        Debug.Log(Data);
       
    }

    public Color getColorByNormalizedPosition(float X, float Y)
    {
        int x = (int)(X * (Width / 2)) + (Width / 2);
        int y = (int)(Y * (Height / 2)) + (Height / 2);
        Debug.Log("color");
        Debug.Log("Height " + Height + ", Width: " + Width + ", X: " + x+ ",Y : " + y);
        if (x > 0 && x < Width && y > 0 && y < Height)
        {
            return Data[y * Width + x];
        }
        return Color.black;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
