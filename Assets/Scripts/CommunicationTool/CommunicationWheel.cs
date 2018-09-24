using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public enum typeSetting { russell = 0, unit = 1 }


public class CommunicationWheel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // required interface when using the OnPointerDown method.
{
    public float doubleClickTime;
    public GameObject crosshair;
    public Color Color;

    private GameObject anchor;
    private GameObject text;
    private GameObject anchorRepresentation;

    private typeSetting pointsSetting;

    Color[] Data;
    Image ImageRenderer;

    public int Width { get { return ImageRenderer.sprite.texture.width; } }
    public int Height { get { return ImageRenderer.sprite.texture.height; } }

    public int ScreenHeight { get { return Camera.main.pixelHeight; } }
    public int ScreenWidth { get { return Camera.main.pixelWidth; } }

    private bool pointerDown;
	private float lastClickTime;

    private bool doubleClick;

    private List<GameObject> anchorPoints = new List<GameObject>();

    private RectTransform circle;
    private RectTransform crosshairRect;
    private Vector2 localCursor;
    private PdAPI pd;
    private PointerEventData click;
    //colorForGame =  public Color getColorByNormalizedPosition(float X, float Y);
    public void OnPointerDown(PointerEventData data)
    {
        if (Time.time - lastClickTime < doubleClickTime/1000) {
            doubleClick = true;
        }
        pointerDown = true;
        click = data;
        lastClickTime = Time.time;
        Vector2 pos = new Vector2((localCursor.x / circle.sizeDelta.x) * 2, (localCursor.y / circle.sizeDelta.y) * 2);
        if (Vector2.Distance(pos, new Vector2(0,0)) <= 1) {
            if (doubleClick) {
                pd.changeValue(new double[] {pos[0],pos[1]});

                restAPI.SendUsage(pos[0], pos[1], true);
                restAPI.SendSetting(GameControl.control.visualization, GameControl.control.representation);

                pd.playAudio();
            }
        }
    }

    public void OnPointerUp(PointerEventData data) 
    {
        pointerDown = false;
        doubleClick = false;
    }
    // Use this for initialization
    void Start() {
        pd = GameObject.Find("PureData").GetComponent<PdAPI>();

        anchor = (GameObject)Instantiate(Resources.Load("Prefabs/anchor"));
        text  = (GameObject)Instantiate(Resources.Load("Prefabs/Text"));
        if (GameControl.control.representation == 0) anchorRepresentation = anchor;
        else anchorRepresentation = text;

        circle = GetComponent<RectTransform>();
        crosshairRect = crosshair.GetComponent<RectTransform>();
        ImageRenderer = circle.GetComponent<Image>();
        Data = ImageRenderer.sprite.texture.GetPixels();
        pointsSetting = (typeSetting) GameControl.control.visualization;
        pd.change_xvecs_type(pointsSetting.EnumToString());
        var positions = pd.get_emo_pos(pointsSetting.EnumToString());
        var emotions = pd.get_targets();
        for (int i = 0; i < positions.Length; i++)
        {
           GameObject anchorPoint = Instantiate(anchorRepresentation,circle);
            anchorPoint.transform.localPosition = new Vector2((float) ((positions[i][0] )* (circle.sizeDelta.x/2)), (float)((positions[i][1])*(circle.sizeDelta.y/2)));
            anchorPoint.name = emotions[i];
            anchorPoints.Add(anchorPoint.gameObject);
          //  anchorPoint.GetComponent<Image>().color = getColorByNormalizedPosition((float)(positions[i][0]), (float)(positions[i][1]));
        }
        crosshair.transform.SetAsLastSibling();
	}

    public void checkSettingsChanges()
    {
        if ((typeSetting)GameControl.control.visualization != pointsSetting)
        {
            pd.change_xvecs_type(pointsSetting.EnumToString());
            pointsSetting = (typeSetting)GameControl.control.visualization;
            var positions = pd.get_emo_pos(pointsSetting.EnumToString());
            var emotions = pd.get_targets();
            for (int i = 0; i < positions.Length; i++ )
            {
                anchorPoints[i].transform.localPosition = new Vector2((float)((positions[i][0]) * (circle.sizeDelta.x / 2)), (float)((positions[i][1]) * (circle.sizeDelta.y / 2)));
                anchorPoints[i].name = emotions[i];
            }
        }
        if((GameControl.control.representation == 0 && anchorRepresentation != anchor))
        {
            foreach (var anchor in anchorPoints) Destroy(anchor);
            anchorRepresentation = anchor;
            anchorPoints = new List<GameObject>();
            var positions = pd.get_emo_pos(pointsSetting.EnumToString());
            var emotions = pd.get_targets();
            for (int i = 0; i < positions.Length; i++)
            {
                GameObject anchorPoint = Instantiate(anchorRepresentation, circle);
                anchorPoint.transform.localPosition = new Vector2((float)((positions[i][0]) * (circle.sizeDelta.x / 2)), (float)((positions[i][1]) * (circle.sizeDelta.y / 2)));
                anchorPoint.name = emotions[i];
                anchorPoints.Add(anchorPoint.gameObject);
                //  anchorPoint.GetComponent<Image>().color = getColorByNormalizedPosition((float)(positions[i][0]), (float)(positions[i][1]));
            }
            crosshair.transform.SetAsLastSibling();
        }
            else if (GameControl.control.representation == 1 && anchorRepresentation != text)
        {
            foreach (var anchor in anchorPoints) Destroy(anchor);
            anchorRepresentation = text;
            var emotions = pd.get_targets();
            anchorPoints = new List<GameObject>();
            var positions = pd.get_emo_pos(pointsSetting.EnumToString());
            for (int i = 0; i < positions.Length; i++)
            {
                GameObject anchorPoint = Instantiate(anchorRepresentation, circle);
                anchorPoint.transform.localPosition = new Vector2((float)((positions[i][0]) * (circle.sizeDelta.x / 2)), (float)((positions[i][1]) * (circle.sizeDelta.y / 2)));
                anchorPoint.name = emotions[i];
                anchorPoints.Add(anchorPoint.gameObject);
                //  anchorPoint.GetComponent<Image>().color = getColorByNormalizedPosition((float)(positions[i][0]), (float)(positions[i][1]));
            }
            crosshair.transform.SetAsLastSibling();
        }
    }
	

    public  Color getColorByNormalizedPosition( float X,  float Y)
    {
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
        checkSettingsChanges();
        if (pointerDown) {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(circle, click.position, click.pressEventCamera, out localCursor))
                return;
            int xRect = (int)circle.sizeDelta.x;
            int yRect = (int)circle.sizeDelta.y;
            Vector2 pos = new Vector2((localCursor.x / xRect) * 2, (localCursor.y / yRect) * 2);
            if (Vector2.Distance(pos, new Vector2(0,0)) <= 1) {

                int x = (int)(pos.x * (Width/2)) + (Width/2);
                int y = (int)(pos.y * (Height/2)) + (Height /2);

                if (x > 0 && x < Width && y > 0 && y < Height)
                {
                    Color = getColorByNormalizedPosition(pos.x,pos.y);
                }

                crosshairRect.position = new Vector3(click.position.x, click.position.y, 0);
                GameControl.control.soundPosition = pos;
                GameControl.control.crosshairPosition = crosshairRect.position;
            }
        }

    
    }
}