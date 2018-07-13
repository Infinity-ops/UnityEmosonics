using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetSound : MonoBehaviour {

	public GameObject crosshair;
	// Use this for initialization
	public void resetPosition () {
		crosshair.GetComponent<RectTransform>().position = GameControl.control.lastCrosshairPos;
		GameControl.control.soundPosition = GameControl.control.lastSoundPosition;
	}
}
