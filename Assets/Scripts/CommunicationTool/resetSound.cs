using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * resets position of crosshair
 */
public class resetSound : MonoBehaviour {

	public GameObject crosshair;
	
	/**
	 * reset the position of the crosshair to the position
	 * of the last played sound
	 */
	public void resetPosition () {
		crosshair.GetComponent<RectTransform>().position = GameControl.control.lastCrosshairPos;
		GameControl.control.soundPosition = GameControl.control.lastSoundPosition;
	}
}
