using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptBall : MonoBehaviour {
    public  GameObject[] gameObject;
    private static int i;
    public static GameObject lastGb;
    // Use this for initialization
    void Start()
    {
        lastGb = gameObject[0];
    }
    // Update is called once per frame
    void Update()
    {
       
        if (DestroyPrefab.destroy > 0)
        { 
            i = DestroyPrefab.destroy;
            Debug.Log(i);
            DestroyObject(gameObject[i]);
            Debug.Log(gameObject[i]);
            //GameObject[DestroyPrefab.destroy];
        }

    }
  
}
