using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePosition : MonoBehaviour {

	public GameObject crosshair;
    
	// Use this for initialization
 	public void change() {
        
		if(this.name.EndsWith("1")) {
			if (GameControl.control.favorite1Pos != new Vector3()) {
                Debug.Log("Color: " + GameControl.control.favorite1Color);

                GameObject.Find("Wheel").GetComponent<CommunicationWheel1>().Color = GameControl.control.favorite1Color;
				crosshair.GetComponent<RectTransform>().position = GameControl.control.favorite1Pos;
				GameControl.control.crosshairPosition = GameControl.control.favorite1Pos;
				GameControl.control.soundPosition = GameControl.control.favorite1Sound;
				restAPI.SendFavorite(GameControl.control.soundPosition[0], GameControl.control.soundPosition[1], 1);
			}
        }
		if(this.name.EndsWith("2")) {
			if (GameControl.control.favorite2Pos != new Vector3()) {
                GameObject.Find("Wheel").GetComponent<CommunicationWheel1>().Color = GameControl.control.favorite2Color;
                crosshair.GetComponent<RectTransform>().position = GameControl.control.favorite2Pos;
				GameControl.control.crosshairPosition = GameControl.control.favorite2Pos;
				GameControl.control.soundPosition = GameControl.control.favorite2Sound;
				restAPI.SendFavorite(GameControl.control.soundPosition[0], GameControl.control.soundPosition[1], 2);
			}
        }
		if(this.name.EndsWith("3")) {
			if (GameControl.control.favorite3Pos != new Vector3()) {
                GameObject.Find("Wheel").GetComponent<CommunicationWheel1>().Color = GameControl.control.favorite3Color;
                crosshair.GetComponent<RectTransform>().position = GameControl.control.favorite3Pos;
				GameControl.control.crosshairPosition = GameControl.control.favorite3Pos;
				GameControl.control.soundPosition = GameControl.control.favorite3Sound;
				restAPI.SendFavorite(GameControl.control.soundPosition[0], GameControl.control.soundPosition[1], 3);
			}
        }
		if(this.name.EndsWith("4")) {
			if (GameControl.control.favorite4Pos != new Vector3()) {
                GameObject.Find("Wheel").GetComponent<CommunicationWheel1>().Color = GameControl.control.favorite4Color;
                crosshair.GetComponent<RectTransform>().position = GameControl.control.favorite4Pos;
				GameControl.control.crosshairPosition = GameControl.control.favorite4Pos;
				GameControl.control.soundPosition = GameControl.control.favorite4Sound;
				restAPI.SendFavorite(GameControl.control.soundPosition[0], GameControl.control.soundPosition[1], 4);
			}
        }
        
	}
}
