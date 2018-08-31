using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommunicationWheel1_Game : MonoBehaviour
{
   public GameObject crosshair;
    Color[] Data;
   private RectTransform circle;
    Image ImageRenderer;
    private bool pointerDown;
    private PdAPI pd;
    private RectTransform crosshairRect;
    private Vector2 localCursor;
    private Vector2 mousePosition;
    private float lastClickTime;
    private float doubleClickTime;

    private bool doubleClick;
    private bool singleClick;
    private PointerEventData click;
    private void OnMouseDown()
    {
        if (Time.time - lastClickTime < doubleClickTime / 1000)
        {
            doubleClick = true;
        }
        lastClickTime = Time.time;
        Vector2 pos = new Vector2((localCursor.x / circle.sizeDelta.x) * 2, (localCursor.y / circle.sizeDelta.y) * 2);
        localCursor.x = Input.mousePosition.x;
        localCursor.y = Input.mousePosition.y;
        float dist = Vector2.Distance(pos, new Vector2(0, 0));
        pointerDown = true;
        if (Vector2.Distance(pos, new Vector2(0, 0)) <= 1)
        {
            if (doubleClick)
            {
                pd.changeValue(new double[] { pos[0], pos[1] });
                pd.playAudio();
            }
        }
        //Debug.Log("Down");
    }

    private void  OnMouseUp() 
    {
        singleClick = false;
        doubleClick = false;
        pointerDown = false;
        //Debug.Log("Up");        
    }
    // Use this for initialization
    void Start () {
        pd = GameObject.Find("PureData").GetComponent<PdAPI>();
        circle = GetComponent<RectTransform>();
        crosshairRect = crosshair.GetComponent<RectTransform>();
        ImageRenderer = circle.GetComponent<Image>();
         //Data = ImageRenderer.texture.GetPixels();
    }
    void Update(){
         if (pointerDown) {
            Vector2 pos = new Vector2((localCursor.x / circle.sizeDelta.x) * 2, (localCursor.y / circle.sizeDelta.y) * 2);
            float dist = Vector2.Distance(pos, new Vector2(0, 0));
            if (Vector2.Distance(pos, new Vector2(0, 0)) <= 1)
            {
                if (doubleClick)
                {
                    pd.changeValue(new double[] { pos[0], pos[1] });
                    pd.playAudio();
                }

                //Vector2 pos = new Vector2((localCursor.x / circle.sizeDelta.x) * 2, (localCursor.y / circle.sizeDelta.y) * 2);
                crosshairRect.position = new Vector3(localCursor.x, localCursor.y, 0);
                GameControl.control.soundPosition = pos;
                GameControl.control.crosshairPosition = crosshairRect.position;
            }
        
    }	
    }
}
