using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {
   // private PdAPI pd;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        
    }
   public void play() {
        PdAPI pd = GameObject.Find("PureData").GetComponent<PdAPI>();
        double[] pos = new double[] { Random.Range(-1, 1), Random.Range(-1, 1) };
        pd.changeValue(pos);
        pd.playAudio();
    }
}
