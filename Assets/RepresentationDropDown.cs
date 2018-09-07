using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepresentationDropDown : MonoBehaviour {
    private Dropdown dropDown;
    // Use this for initialization
    void Start()
    {
        dropDown = GetComponent<Dropdown>();
        dropDown.value = GameControl.control.representation;
    }

    public void updateRepresentation()
    {
        GameControl.control.representation = dropDown.value;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
