using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyPrefab : MonoBehaviour
{
    GameObject player;

    private GameObject StonePrefab;
    private GameObject Stone;
    public static int destroy;
    void OnTriggerEnter(Collider collider)
    {
        if (!player || (player && collider.gameObject.tag == "player"))
        {
          
            LivesCount.livesValue -= 1;
            destroy = LivesCount.livesValue;
            if(destroy == 0)
            {
                DestroyObject(AttemptBall.lastGb);
            }
            StonePrefab = GameObject.FindGameObjectWithTag("Projectile");
            DestroyObject(StonePrefab);
            //  Stone = GameObject.FindGameObjectWithTag("Stone");
            //  DestroyObject(Stone);
        }
    }

}
