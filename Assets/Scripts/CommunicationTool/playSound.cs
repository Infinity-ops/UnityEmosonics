using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * plays sound based position of crosshair
 */
public class playSound : MonoBehaviour
{

    // Use this for initialization
    private PdAPI pd;

    public GameObject crosshair;

    /**
     * plays sound based on relative position of crosshair
     * within communication wheel in terms of x,y coordinates
     * in a range between -1 and 1
     */
    public void play()
    {
        pd = GameObject.Find("PureData").GetComponent<PdAPI>();
        Vector2 pos = GameControl.control.soundPosition;
        pd.changeValue(new double[] { pos[0], pos[1] });
        restAPI.SendUsage(pos[0], pos[1], false);
        restAPI.SendSetting(GameControl.control.visualization, GameControl.control.representation);
        pd.playAudio();
        GameControl.control.lastCrosshairPos = crosshair.GetComponent<RectTransform>().position;
        GameControl.control.lastSoundPosition = pos;
    }
}
