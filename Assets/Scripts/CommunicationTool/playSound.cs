using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{

    // Use this for initialization
    private PdAPI pd;

    public GameObject crosshair;

    void Start()
    {

    }

    // Update is called once per frame
    public void play()
    {
        pd = GameObject.Find("PureData").GetComponent<PdAPI>();
        Vector2 pos = GameControl.control.soundPosition;
        pd.changeValue(new double[] { pos[0], pos[1] });
        restAPI.SendUsage(pos[0], pos[1], false);
        //Debug.Log("Playsound" + pos);
        pd.playAudio();
        GameControl.control.lastCrosshairPos = crosshair.GetComponent<RectTransform>().position;
        GameControl.control.lastSoundPosition = pos;
    }
}
