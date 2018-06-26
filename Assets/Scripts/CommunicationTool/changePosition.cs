﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePosition : MonoBehaviour {

	public GameObject crosshair;

	// Use this for initialization
 	public void change() {
		if(this.name.EndsWith("1")) {
			if (GameControl.control.favorite1Pos != new Vector3()) {
				crosshair.GetComponent<RectTransform>().position = GameControl.control.favorite1Pos;
				GameControl.control.crosshairPosition = GameControl.control.favorite1Pos;
				GameControl.control.soundPosition = GameControl.control.favorite1Sound;
			}
        }
		if(this.name.EndsWith("2")) {
			if (GameControl.control.favorite2Pos != new Vector3()) {
				crosshair.GetComponent<RectTransform>().position = GameControl.control.favorite2Pos;
				GameControl.control.crosshairPosition = GameControl.control.favorite2Pos;
				GameControl.control.soundPosition = GameControl.control.favorite2Sound;
			}
        }
		if(this.name.EndsWith("3")) {
			if (GameControl.control.favorite3Pos != new Vector3()) {
				crosshair.GetComponent<RectTransform>().position = GameControl.control.favorite3Pos;
				GameControl.control.crosshairPosition = GameControl.control.favorite3Pos;
				GameControl.control.soundPosition = GameControl.control.favorite3Sound;
			}
        }
		if(this.name.EndsWith("4")) {
			if (GameControl.control.favorite4Pos != new Vector3()) {
				crosshair.GetComponent<RectTransform>().position = GameControl.control.favorite4Pos;
				GameControl.control.crosshairPosition = GameControl.control.favorite4Pos;
				GameControl.control.soundPosition = GameControl.control.favorite4Sound;
			}
        }
        
	}
}