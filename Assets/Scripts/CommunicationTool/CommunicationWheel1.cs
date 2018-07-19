using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CommunicationWheel1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // required interface when using the OnPointerDown method.
{
    public float doubleClickTime;
    public GameObject crosshair;

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
	}
	

	// Update is called once per frame
private void Update()
    {
        if (pointerDown) {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(circle, click.position, click.pressEventCamera, out localCursor))
                return;
            Vector2 pos = new Vector2((localCursor.x / circle.sizeDelta.x) * 2, (localCursor.y / circle.sizeDelta.y) * 2);
            float dist = Vector2.Distance(pos, new Vector2(0,0));
            if (Vector2.Distance(pos, new Vector2(0,0)) <= 1) {
                crosshairRect.position = new Vector3(click.position.x, click.position.y, 0);
                GameControl.control.soundPosition = pos;
                GameControl.control.crosshairPosition = crosshairRect.position;
            }
        }
    }
}