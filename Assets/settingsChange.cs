using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsChange : MonoBehaviour {
    private Dropdown dropDownRepresentation;
    private Dropdown dropDownVisualization;
    private Dropdown dropDownSoundSetting;

	// Use this for initialization
	void Start () {
        dropDownRepresentation = GameObject.Find("Representation").GetComponent<Dropdown>();
        dropDownRepresentation.value = GameControl.control.visualization;

        dropDownVisualization = GameObject.Find("Visualization").GetComponent<Dropdown>();
        dropDownVisualization.value = GameControl.control.representation;

        dropDownSoundSetting = GameObject.Find("SoundSetting").GetComponent<Dropdown>();
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
