using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class spriteWheel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // required interface when using the OnPointerDown method.
{
    public float doubleClickTime;
    public GameObject crosshair;

    public Image image;

    Color[] colors;

    private bool pointerDown;
    private float lastClickTime;

    private bool doubleClick;
    private bool singleClick;

    private RectTransform circle;
    private RectTransform crosshairRect;
    private Vector2 localCursor;
    private PdAPI pd;
    private PointerEventData click;

    private Texture2D communicationWheelTexture;
    private Sprite wheelSprite;

    public void OnPointerDown(PointerEventData data)
    {
        if (Time.time - lastClickTime > doubleClickTime / 1000)
        {
            singleClick = true;
        }
        else
        {
            doubleClick = true;
        }
        pointerDown = true;
        click = data;
        lastClickTime = Time.time;
    }

    public void OnPointerUp(PointerEventData data)
    {
        pointerDown = false;
        singleClick = false;
        doubleClick = false;
    }
    // Use this for initialization
    void Start()
    {
        circle = GetComponent<RectTransform>();
        pd = GameObject.Find("PureData").GetComponent<PdAPI>();
        crosshairRect = crosshair.GetComponent<RectTransform>();

        wheelSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        communicationWheelTexture = wheelSprite.texture;
        colors = communicationWheelTexture.GetPixels();

    }


    // Update is called once per frame
    private void Update()
    {
        if (pointerDown)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(circle, click.position, click.pressEventCamera, out localCursor))
                return;

            Vector3 screenPos = Camera.main.ScreenToWorldPoint(click.position);
            screenPos = new Vector2(screenPos.x, screenPos.y);
            RaycastHit2D[] ray = Physics2D.RaycastAll(screenPos, Vector2.zero, 0.01f);
            Debug.Log("Hey:" + ray.Length);
            for (int i = 0; i < ray.Length; i++)
            {
                // You will want to tag the image you want to lookup
                if (ray[i].collider.tag == "TAGNAME")
                {
                    // Set click position to the gameobject area
                    screenPos -= ray[i].collider.gameObject.transform.position;
                    int x = (int)(screenPos.x * communicationWheelTexture.width);
                    int y = (int)(screenPos.y * communicationWheelTexture.height) + communicationWheelTexture.height;

                    // Get color data
                    if (x > 0 && x < communicationWheelTexture.width && y > 0 && y < communicationWheelTexture.height)
                    {
                        Debug.Log("Color:" + colors[y * communicationWheelTexture.width + x]);
                    }
                    break;
                }
            }
            Vector2 pos = new Vector2((localCursor.x / circle.sizeDelta.x) * 2, (localCursor.y / circle.sizeDelta.y) * 2);
            float dist = Vector2.Distance(pos, new Vector2(0, 0));
            if (Vector2.Distance(pos, new Vector2(0, 0)) <= 1)
            {

                if (doubleClick)
                {
                    pd.changeValue(new double[] { pos[0], pos[1] });
                    pd.playAudio();
                }
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
