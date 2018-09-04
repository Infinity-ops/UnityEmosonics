using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsChange : MonoBehaviour {
    private Dropdown dropDown;
	// Use this for initialization
	void Start () {
        dropDown = GetComponent<Dropdown>();
        dropDown.value = GameControl.control.visualization;
	}
	
    public void updateRepresentation()
    {
        GameControl.control.visualization = dropDown.value;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
