using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsChange : MonoBehaviour {
    private Dropdown dropDownRepresentation;
    private Dropdown dropDownVisualization;
	// Use this for initialization
	void Start () {
        dropDownRepresentation = GameObject.Find("Representation").GetComponent<Dropdown>();
        dropDownRepresentation.value = GameControl.control.visualization;
        dropDownVisualization = GameObject.Find("Visualization").GetComponent<Dropdown>();
        dropDownVisualization.value = GameControl.control.representation;

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
