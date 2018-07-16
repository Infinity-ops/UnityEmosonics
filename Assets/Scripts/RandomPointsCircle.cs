using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointsCircle : MonoBehaviour {
    public CircleCollider2D cc;
    float radius,x,y,z;
    Vector3 pos;
    // Use this for initialization
    void Start () {
        radius = cc.radius;
        Debug.Log(radius);
        x = Random.Range(-radius, radius);
        z = 0;
        y = Random.Range(-radius, radius);
        pos = new Vector3(x, y, z);
        // transform.position = pos;
        Debug.Log("Random Points inside the circle:" +pos);
    }
	
	// Update is called once per frame
	void Update () {
       

    }
}
