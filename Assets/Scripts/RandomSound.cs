using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{

    // Use this for initialization
    private PdAPI pd;

    void Start()
    {
        pd = GameObject.Find("PureData").GetComponent<PdAPI>();
        //Invoke("play", 2.0f);
    }

    /**
     * it plays random sound from the pd
     */

    public void play()
    {
        double[] pos = { GameManagerTool.xrand, GameManagerTool.yrand };
        // double[] pos = new double[] { Random.Range(-1f, 1f), Random.Range(-1f, 1f) };
       
        pd.changeValue(pos);   
        // print("x" + pos[0].ToString());
        //print("y" + pos[1].ToString());
        pd.playAudio();
    }
}
