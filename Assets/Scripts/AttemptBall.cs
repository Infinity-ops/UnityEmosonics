using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script is for referring the number of Attempt balls in the game
 * For every wrong hit, one attempt ball  will destroy
 */
public class AttemptBall : MonoBehaviour {
    public GameObject ball;  /**< This ball refers to sphere in DragHandle GAmeobject */
    public static bool destroy;  /**< To check whether all attempt ball is destroyed or not*/
   public static GameObject ball1,ball2,ball3;  /**< This Gameobject refers to Attempt balls*/
    public static bool ballCheck2, ballCheck1, ballCheck3; /**<To check whether attempt ball is destroyed or not*/

    // Use this for initialization
    void Start()
    {
        ballCheck1 = false;
        ballCheck2 = false;
        ballCheck3 = false;
        destroy = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameManagerTool.realAttemptBall == true || LivesCount.nextLevelBool == true)
        {
             ball1 = GameObject.FindWithTag("ball1");
             ball2 = GameObject.FindWithTag("ball2");
             ball3 = GameObject.FindWithTag("ball3");
            GameManagerTool.realAttemptBall = false;
            LivesCount.nextLevelBool = false;
        }

        if (GameCollider.testPass1 == true || GameManagerTool.testPass3 == true)
        {
            GameCollider.testPass1 = false;
            GameManagerTool.testPass3 = false;
            LivesCount.livesValue -= 1;
            destroy = true;
            if (destroy)
            {
                if (ball1!=null)
                {
                    Destroy(GameObject.FindWithTag("ball1"));
                    ballCheck1 = true;
                    destroy = false;
                }
                if (ball2 && destroy == true)
                {
                    Destroy(GameObject.FindWithTag("ball2"));
                    ballCheck2 = true;
                    destroy = false;
                }
                if (ball3 && destroy == true)
                {
                    Destroy(GameObject.FindWithTag("ball3"));
                    ballCheck3 = true;
                    destroy = false;
                }
            }
            ball.SetActive(true);
            destroy = false;
        }
        if (Triggertest.testPass2 == true)
        {
            Triggertest.testPass2 = false;
            LivesCount.livesValue -= 1;
            destroy = true;
            if (destroy)
            {
                if (ball1 != null)
                {
                    Destroy(GameObject.FindWithTag("ball1"));
                    ballCheck1 = true;
                    destroy = false;
                }
                if (ball2 && destroy == true)
                {
                    Destroy(GameObject.FindWithTag("ball2"));
                    ballCheck2 = true;
                    destroy = false;
                }
                if (ball3 && destroy == true)
                {
                    Destroy(GameObject.FindWithTag("ball3"));
                    ballCheck3 = true;
                    destroy = false;
                }
            }
            ball.SetActive(true);
            destroy = false;
        }
    }
}
