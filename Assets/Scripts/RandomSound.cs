using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSound : MonoBehaviour
{

    // Use this for initialization
    private PdAPI pd;

    void Start()
    {
        pd = GameObject.Find("PureData").GetComponent<PdAPI>();
    }

    // Update is called once per frame
    public void play()
    {
        double[] pos = { Duplicator.xrand, Duplicator.yrand };
       // double[] pos = new double[] { Random.Range(-1f, 1f), Random.Range(-1f, 1f) };
        pd.changeValue(pos);
        print("x" + pos[0].ToString());
        print("y" + pos[1].ToString());
        pd.playAudio();
    }
}
