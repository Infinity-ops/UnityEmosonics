using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBalloon : MonoBehaviour {
    public GameObject[] balloons;
    
    public int waypointsCount;
    // Use this for initialization
    void Start () {
        var randomObjects = new GameObject[waypointsCount];
        for (int i = 0; i < waypointsCount; i++)
        {
            int take = Random.Range(i, balloons.Length);
            randomObjects[i] = balloons[take];

            // Swap our random choice to the beginning of the array,
            // so we don't choose it again on subsequent iterations.
            balloons[take] = balloons[i];
            balloons[i] = randomObjects[i];
        }
     

    }
    


}
