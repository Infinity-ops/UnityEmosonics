using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColliding : MonoBehaviour {
   
    public static int testPass; //AttemptBall Delete
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered*********");
        testPass = 1;
    }
   
}
