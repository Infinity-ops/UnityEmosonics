using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for "GameObject:Collider".
//Game Object 'Collider' includes a Box Collider which triggers if ball hits outside the Dart Board.

public class GameCollider : MonoBehaviour {
   
    public static bool testPass1; //AttemptBall Delete
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
       
        testPass1 = true;
    }
   
}
