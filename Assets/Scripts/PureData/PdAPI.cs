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
    void Awake () {
        kr = gameObject.AddComponent<KernelRegression>();

        PureData.OpenPatch("abstractlatest");
    }

    void updateParam(double[] paramVec)
    {
        /*
        pointer = 1.0f;//(float) paramVec[0];
        duration = (float) paramVec[0];
        attack = (float) paramVec[1];
        desvol = (float)paramVec[2];
        pitch = (float)paramVec[3];
        chirp = (float)paramVec[4];
        lfndepth = (float)paramVec[5];
        lfnfreq = (float)paramVec[6];
        amdepth = (float)paramVec[7];
        amfreq = (float)paramVec[8];
        richness = (float)paramVec[9];
        */

        
        pointer = 1.0f;//(float) paramVec[0];
        duration = 0.75f;
        attack = 0.2f;
        desvol = -30.0f;
        pitch = 56.0f;
        chirp = 12.0f;
        lfndepth = 0.3f;
        lfnfreq = 3.0f;
        amdepth = 0.2f;
        amfreq = 0.5f;
        richness = 1.0f; 
    }

    //change the value of the parameters in the pd patch
    public void changeValue(double[] posxy)
    {
        double[] paramVec = kr.Krm(posxy, sigma);
        debug(paramVec);
        updateParam(paramVec);
        PureData.SendMessage(TOUCHSYMBOL, MESSAGE, pointer, duration, attack, desvol, pitch, chirp, lfndepth, lfnfreq, amdepth, amfreq, richness);
    }

    //sends a trigger message to play the audio
    public void playAudio()
    {
        PureData.SendMessage(TOUCHSYMBOL, TRIGGER, BANG);
    }

    private void debug(double[] par)
    {
        foreach(double p in par)
        {
            print(p);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
