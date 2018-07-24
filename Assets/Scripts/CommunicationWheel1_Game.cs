using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CommunicationWheel1_Game : MonoBehaviour
{
   public GameObject crosshair;
   private RectTransform circle;
   private bool pointerDown;
   private RectTransform crosshairRect;
    private Vector2 localCursor;
    private Vector2 mousePosition;
    private void OnMouseDown()
    {
        localCursor.x = Input.mousePosition.x;
        localCursor.y = Input.mousePosition.y;
         pointerDown = true;
        //Debug.Log("Down");
    }

    private void  OnMouseUp() 
    {
         pointerDown = false;
        //Debug.Log("Up");        
    }
    // Use this for initialization
    void Start () {
		circle = GetComponent<RectTransform>();
        crosshairRect = crosshair.GetComponent<RectTransform>();
	}
    void Update(){
         if (pointerDown) {
            

            Vector2 pos = new Vector2((localCursor.x / circle.sizeDelta.x) * 2, (localCursor.y / circle.sizeDelta.y) * 2);
            crosshairRect.position = new Vector3(localCursor.x, localCursor.y, 0);
          //  GameControl.control.soundPosition = pos;
           // GameControl.control.crosshairPosition = crosshairRect.position;
        }	
    }
}
