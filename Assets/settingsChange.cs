using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsChange : MonoBehaviour {
    public Dropdown dropDownRepresentation;
    public Dropdown dropDownVisualization;
    public Dropdown dropDownSoundSetting;

	// Use this for initialization
	void Start () {
        dropDownRepresentation.value = GameControl.control.visualization;

        dropDownVisualization.value = GameControl.control.representation;

        dropDownSoundSetting.value = GameControl.control.soundSetting;
    }

    public void updateSoundSetting()
    {
        GameControl.control.soundSetting = dropDownSoundSetting.value;
    }
	
    public void updateRepresentation()
    {
        GameControl.control.visualization = dropDownRepresentation.value;
    }

    public void updateVisualization()
    {
        GameControl.control.representation = dropDownVisualization.value;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
