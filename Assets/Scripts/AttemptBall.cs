using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptBall : MonoBehaviour {
    
    private int i = 0;
    public static bool destroy;
   public static GameObject ball1,ball2,ball3;
  
    // Use this for initialization
    void Start()
    {
       
       
        destroy = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Duplicator.realAttemptBall == true || LivesCount.nextLevelBool == true)
        {
             ball1 = GameObject.FindWithTag("ball1");
             ball2 = GameObject.FindWithTag("ball2");
             ball3 = GameObject.FindWithTag("ball3");
            //i = gameObject.Length;
            Duplicator.realAttemptBall = false;
            LivesCount.nextLevelBool = false;
        }

        if (TestColliding.testPass1 == true || Duplicator.testPass3 == true)
        {

            TestColliding.testPass1 = false;
            Duplicator.testPass3 = false;
            LivesCount.livesValue -= 1;
            destroy = true;
            if (destroy)
            {
                if (ball1!=null)
                {
                    Destroy(GameObject.FindWithTag("ball1"));
                    destroy = false;
                }
                if (ball2 && destroy == true)
                {
                    Destroy(GameObject.FindWithTag("ball2"));
                    destroy = false;
                }
                if (ball3 && destroy == true)
                {
                    Destroy(GameObject.FindWithTag("ball3"));
                    destroy = false;
                }

                    //Destroy(Duplicator.attemptBall1);
                }

        }
        if (Triggertest.testPass2 == true)
        {
            Triggertest.testPass2 = false;
            LivesCount.livesValue -= 1;
            destroy = true;
            if (ball1 != null)
            {
                Destroy(GameObject.FindWithTag("ball1"));
                destroy = false;
            }
            if (ball2 && destroy == true)
            {
                Destroy(GameObject.FindWithTag("ball2"));
                destroy = false;
            }
            if (ball3 && destroy == true)
            {
                Destroy(GameObject.FindWithTag("ball3"));
                destroy = false;
            }

            //Destroy(Duplicator.attemptBall1);
        }

        //bg.isTrigger == false;
    
      
 

    }
  
}
