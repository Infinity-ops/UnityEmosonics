using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PdAPI : MonoBehaviour {
    private KernelRegression kr;
    private string TOUCHSYMBOL = "#touch";
    private string MESSAGE = "abstract";
    private string TRIGGER = "aTrigger";
    private string BANG = "bang";
    private double sigma = 0.7;
    private float pointer, duration, attack, desvol, pitch, chirp, lfndepth, lfnfreq,
    amdepth, amfreq, richness;

    // Use this for initialization
    void Start () {
        kr = new KernelRegression();

        PureData.OpenPatch("abstractlatest");
    }

    void updateParam(double[] paramVec)
    {
        pointer = (float) paramVec[0];
        duration = (float) paramVec[1];
        attack = (float) paramVec[2];
        desvol = (float)paramVec[3];
        pitch = (float)paramVec[4];
        chirp = (float)paramVec[5];
        lfndepth = (float)paramVec[6];
        lfnfreq = (float)paramVec[7];
        amdepth = (float)paramVec[8];
        amfreq = (float)paramVec[9];
        richness = (float)paramVec[10];
    }

    //change the value of the parameters in the pd patch
    public void changeValue(double[] posxy)
    {
        double[] paramVec = kr.Krm(posxy, sigma);
        updateParam(paramVec);
        PureData.SendMessage(TOUCHSYMBOL, MESSAGE, pointer, duration, attack, desvol, pitch, chirp, lfndepth, lfnfreq, amdepth, amfreq, richness);
    }

    //sends a trigger message to play the audio
    public void playAudio()
    {
        PureData.SendMessage(TOUCHSYMBOL, TRIGGER, BANG);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
