using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicking : MonoBehaviour {

    Color[] Data;
    Image SpriteRenderer;
    private Vector2 localCursor;

   public GameObject ColorPicker;
    GameObject Selector;
    CircleCollider2D Collider;

    public int Width { get { return SpriteRenderer.sprite.texture.width; } }
    public int Height { get { return SpriteRenderer.sprite.texture.height; } }
    public int ScreenWidth { get { return Camera.current.pixelWidth; } }
    public int ScreenHeight { get { return Camera.current.pixelHeight; } }

    public Color Color;

    void Awake()
    {

        ColorPicker = transform.Find("Image").gameObject;
        SpriteRenderer = ColorPicker.GetComponent<Image>();
      Selector = transform.Find("Crosshair").gameObject;
        Collider = ColorPicker.GetComponent<CircleCollider2D>();

        Data = SpriteRenderer.sprite.texture.GetPixels();
        Debug.Log("Data:" + Data.Length);
        Color = Color.white;
    }

   
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse down...");
            RectTransformUtility.ScreenPointToLocalPointInRectangle(ColorPicker.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out localCursor);
            Vector3 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            screenPos = new Vector2(screenPos.x, screenPos.y);

            //check if we clicked this picker control
            RaycastHit2D[] ray = Physics2D.RaycastAll(screenPos, Vector2.zero, 0.01f);
            //Debug.Log("Ray length: " + ray.Lenrectgth);
            for (int i = 0; i < ray.Length; i++)
            {
                
                if (ray[i].collider == Collider)
                {
                    Debug.Log("Ray hit!");
                    //move selector
                   Selector.transform.position = screenPos;

                    //get color data
                    screenPos -= ColorPicker.transform.position;
                    int xRect = (int) ColorPicker.GetComponent<RectTransform>().sizeDelta.x;
                    int yRect = (int)ColorPicker.GetComponent<RectTransform>().sizeDelta.y;

                    int x = (int) (localCursor.x + (xRect /2 )) * (Width/xRect);
                    int y = (int) (localCursor.y + (yRect /2 )) * (Height/yRect) ;
                    //x = x / 2;
                    //y = y / 2;


                    Debug.Log("X: " + x + " Y:" + y + " HEight: " + Height + " Width: " + Width +"Screen heigh: "+ScreenHeight
                        + "Screen Width: "+ScreenWidth + "X Rect: "+xRect);

                    if (x > 0 && x < Width && y > 0 && y < Height)
                    {
                        Color = Data[y * Width + x];
                       Debug.Log("Color: " + Color);
                    }
                    break;
                }
            }

        }
    }
}
