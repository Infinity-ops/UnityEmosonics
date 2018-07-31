using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RandomSound : MonoBehaviour {
    // private PdAPI pd;
    private double[] pos;
    private float radius_range = 1.0f;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        
    }
   public void play() {
        PdAPI pd = GameObject.Find("PureData").GetComponent<PdAPI>();
        double[] random_pos = get_random_pos();
        pd.changeValue(random_pos);
        pd.playAudio();
    }

   public double[] get_random_pos()
    {
        //create random radian and angle
        float r = radius_range * Convert.ToSingle(Math.Sqrt(UnityEngine.Random.Range(0.0f, 1.0f)));
        float theta = UnityEngine.Random.Range(0.0f, 1.0f) * 2.0f * Convert.ToSingle(Math.PI);

        //calculate random x,y coordinate
        double x = Math.Cos(theta) * r;
        double y = Math.Sin(theta) * r;
        pos = new double[] { x, y };

        return pos;

    }
}
