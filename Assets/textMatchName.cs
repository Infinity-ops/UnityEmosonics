using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class textMatchName : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = gameObject.name.First().ToString().ToUpper() + gameObject.name.Substring(1);
    }
}
