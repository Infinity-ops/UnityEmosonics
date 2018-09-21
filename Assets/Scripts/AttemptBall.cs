using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptBall : MonoBehaviour {
   
    public  GameObject[] gameObject;
    public GameObject[] gameObject1; // For Duplicator j
    /// </summary>
    private int i=0, j=0;
    public static GameObject lastGb, lastGb1;
    // Use this for initialization
    void Start()
    {
        lastGb = gameObject[i];
        lastGb1 = gameObject1[j];
    }
    // Update is called once per frame
    void Update()
    {
        if(LockController.realAttemptBall == true)
        {
            i = gameObject.Length;
            LockController.realAttemptBall = false;
        }
        if (Duplicator.realAttemptBall1 == true)
        {
            j = gameObject1.Length;
            Duplicator.realAttemptBall1 = false;
        }

        if (  TestColliding.testPass ==1 || Duplicator.testPass3 ==1 )
        {
            TestColliding.testPass = 0;
            LivesCount.livesValue -= 1;
            DestroyObject(lastGb);
            DestroyObject(lastGb1);
            i--;
            j--;
            lastGb = gameObject[i];
            lastGb1 = gameObject1[j];
            print(i);
            //bg.isTrigger == false;
        }
        if (Triggertest.testPass2 == true)
        {
            Triggertest.testPass2 = false;
            TestColliding.testPass = 0;
            LivesCount.livesValue -= 1;
            DestroyObject(lastGb);
            DestroyObject(lastGb1);
            i--;
            j--;
            lastGb = gameObject[i];
            lastGb1 = gameObject1[j];
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
