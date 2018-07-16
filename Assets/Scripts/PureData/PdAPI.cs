using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PdAPI : MonoBehaviour {
    private KernelRegression kr;
    private float richness_max = 4;
    private float richness_min = 0.5;
    private string TOUCHSYMBOL = "#touch";
    private string MESSAGE = "abstract";
    private string TRIGGER = "aTrigger";
    private string BANG = "bang";
    private double sigma = 0.05;
    private float pointer, duration, attack, desvol, pitch, chirp, lfndepth, lfnfreq,
    amdepth, amfreq, richness;
    private string[] par_names = {"duration", "attack", "desvol", "pitch", "chirp", "lfndepth", "lfnfreq",
    "amdepth", "amfreq", "richness"};

    // Use this for initialization
    void Awake () {
        kr = gameObject.AddComponent<KernelRegression>();

        PureData.OpenPatch("abstractlatest");
    }

    void updateParam(double[] paramVec)
    {
        
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
        

        /*
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
        richness = 1.0f; */
    }

    /* change the value of the parameters in the pd patch
     * @params:
     * posxy = the position in the unit circle from which the sound should by synthesized
     * debug = if true, prints the parameter names and values
     * richness_scale = scale the richness which results in higher/lower volume
     */
    public void changeValue(double[] posxy, bool debug=false, float richness_scale=1.0f)
    {
        double[] paramVec = kr.Krm(posxy, sigma);

        if (debug)
        {
            this.debug(paramVec);
        }

        //scale richness
        richness *= richness_scale;

        if (richness > richness_max)
        {
            richness = richness_max;
        }

        else if (richness < richness_min)
        {
            richness = richness_min;
        }
        
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
        int idx = 0;
        foreach(string s in par_names)
        {
            print(s+": "+par[idx].ToString());
            idx++;
        }
    }
	
}
