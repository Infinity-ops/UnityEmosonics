﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommunicationWheel1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // required interface when using the OnPointerDown method.
{
    public float doubleClickTime;
    public GameObject crosshair;
    public Color Color;

    Color[] Data;
    Image ImageRenderer;

    public int Width { get { return ImageRenderer.sprite.texture.width; } }
    public int Height { get { return ImageRenderer.sprite.texture.height; } }

    public int ScreenHeight { get { return Camera.main.pixelHeight; } }
    public int ScreenWidth { get { return Camera.main.pixelWidth; } }

    private bool pointerDown;
	private float lastClickTime;

    private bool doubleClick;
    private bool singleClick;

    private RectTransform circle;
    private RectTransform crosshairRect;
    private Vector2 localCursor;
    private PdAPI pd;
    private PointerEventData click;
    public void OnPointerDown(PointerEventData data)
    {
        if (Time.time - lastClickTime < doubleClickTime/1000) {
            doubleClick = true;
        }
        pointerDown = true;
        click = data;
        lastClickTime = Time.time;
        Vector2 pos = new Vector2((localCursor.x / circle.sizeDelta.x) * 2, (localCursor.y / circle.sizeDelta.y) * 2);
        float dist = Vector2.Distance(pos, new Vector2(0,0));
        if (Vector2.Distance(pos, new Vector2(0,0)) <= 1) {
            if (doubleClick) {
                pd.changeValue(new double[] {pos[0],pos[1]});
                pd.playAudio();
            }
        }
    }

    public void OnPointerUp(PointerEventData data) 
    {
        pointerDown = false;
        singleClick = false;
        doubleClick = false;
    }
    // Use this for initialization
    void Start () {
		circle = GetComponent<RectTransform>();
        pd = GameObject.Find("PureData").GetComponent<PdAPI>();
        crosshairRect = crosshair.GetComponent<RectTransform>();
        ImageRenderer = circle.GetComponent<Image>();
        Data = ImageRenderer.sprite.texture.GetPixels();
	}
	
    public Color getColorByNormalizedPosition(float X, float Y)
    {
        int xRect = (int)circle.sizeDelta.x;
        int yRect = (int)circle.sizeDelta.y;
        int x = (int)(X * (Width / 2)) + (Width / 2);
        int y = (int)(Y * (Height / 2)) + (Height / 2);

        if (x > 0 && x < Width && y > 0 && y < Height)
        {
           return  Data[y * Width + x];
        }
        return Color.black;
    }

	// Update is called once per frame
private void Update()
    {
        if (pointerDown) {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(circle, click.position, click.pressEventCamera, out localCursor))
                return;
            int xRect = (int)circle.sizeDelta.x;
            int yRect = (int)circle.sizeDelta.y;
            Vector2 pos = new Vector2((localCursor.x / xRect) * 2, (localCursor.y / yRect) * 2);
            float dist = Vector2.Distance(pos, new Vector2(0,0));
            if (Vector2.Distance(pos, new Vector2(0,0)) <= 1) {

                int x = (int)(pos.x * (Width/2)) + (Width/2);
                int y = (int)(pos.y * (Height/2)) + (Height /2);

                if (x > 0 && x < Width && y > 0 && y < Height)
                {
                    Color = getColorByNormalizedPosition(pos.x,pos.y);
                }
                // if (doubleClick) {
                //     pd.changeValue(new double[] {pos[0],pos[1]});
                //     pd.playAudio();
                // }
                /*
                if (singleClick && Time.time - lastClickTime > doubleClickTime/1000) {
                    crosshairRect.position = new Vector3(click.position.x, click.position.y, 0);
                    GameControl.control.soundPosition = pos;
                    GameControl.control.crosshairPosition = crosshairRect.position;
                }*/

                crosshairRect.position = new Vector3(click.position.x, click.position.y, 0);
                GameControl.control.soundPosition = pos;
                GameControl.control.crosshairPosition = crosshairRect.position;
            }
        }
    }
}