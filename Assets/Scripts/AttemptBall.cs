using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptBall : MonoBehaviour {
   
    public  GameObject[] gameObject;
    private int i=0;
    public static GameObject lastGb;
    // Use this for initialization
    void Start()
    {
        lastGb = gameObject[i];
    }
    // Update is called once per frame
    void Update()
    {
        if(LockController.realAttemptBall == true)
        {
            i = gameObject.Length;
            LockController.realAttemptBall = false;
        }

        if(  TestColliding.testPass ==1 || Duplicator.testPass3 ==1 )
        {
            TestColliding.testPass = 0;
            LivesCount.livesValue -= 1;
            DestroyObject(lastGb);
            i--;
            lastGb = gameObject[i];
            print(i);
            //bg.isTrigger == false;
        }
        if (Triggertest.testPass2 == true)
        {
            Triggertest.testPass2 = false;
            TestColliding.testPass = 0;
            LivesCount.livesValue -= 1;
            DestroyObject(lastGb);
            i--;
            lastGb = gameObject[i];
            Triggertest.testPass2 = false;
            //bg.isTrigger == false;
        }

        /*
              if (DestroyPrefab.destroy > 0 )
              { 
                  i = DestroyPrefab.destroy;
                  Debug.Log(i);
                  DestroyObject(gameObject[i]);
                  Debug.Log(gameObject[i]);
                  //GameObject[DestroyPrefab.destroy];
              }
            */

    }
  
}
