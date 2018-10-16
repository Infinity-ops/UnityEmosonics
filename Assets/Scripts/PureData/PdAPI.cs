using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class PdAPI : MonoBehaviour
{
    private KernelRegression kr;
    private JsonLoader JL;
    private AudioSource audioSource;
    private SampleList sl = null;
    private float richness_max = 4;
    private float richness_min = 0.5f;
    private string file = "sample_data.json";
    private string filename = string.Empty;
    private string engine_type = "sample"; //synth or sample
    private string sound_type = "voc"; //voc or inf
    private string xvecs_type = "unit";
    private string TOUCHSYMBOL = "#touch";
    private string MESSAGE = "abstract";
    private string TRIGGER = "aTrigger";
    private string BANG = "bang";
    private double sigma = 0.5;

    private float pointer, duration, attack, desvol, pitch, chirp, lfndepth, lfnfreq,
    amdepth, amfreq, richness;
    private string[] par_names = {"duration", "attack", "desvol", "pitch", "chirp", "lfndepth", "lfnfreq",
    "amdepth", "amfreq", "richness"};

    //test the start mechanic
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1f;

        kr = gameObject.AddComponent<KernelRegression>();
        PureData.OpenPatch("abstractlatest");

        //choose which JsonLoader to use
        if (engine_type == "sample")
        {

            JL = new JsonLoader(file);

            //PureData.OpenPatch("fileplayer");
        }
        else if (engine_type == "synth")
        {
            JL = new JsonLoader();
        }

    }

    private void Update()
    {
        audioSource.volume = 1.0f;
    }

    // Use this for initialization
    void Awake()
    {

    }

    void updateParam(double[] paramVec)
    {

        pointer = 1.0f;//(float) paramVec[0];
        duration = (float)paramVec[0];
        attack = (float)paramVec[1];
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
    public void changeValue(double[] posxy, bool debug = false, float richness_scale = 1.0f)
    {
        //check first whether type of sound to use
        if (engine_type == "sample")
        {
            //call sample function
            string emotion = get_nearest_emotion(posxy);
            
            //load data if not done before
            if(sl == null)
            { 
                sl = JL.Load_samples_info();
            }

            string f = query(emotion, sound_type);

            this.filename = f;
        }

        else
        {
            //use engine to produce sound
            double[] paramVec = kr.Krm(posxy, sigma, xvecs_type);

            if (debug)
            {
                //this.debug(paramVec);
                double[] pv = kr.Krm(posxy, sigma, xvecs_type, true);
                kr.debug(pv, posxy);
            }

            //scale richness
            richness = scale_richness(richness, richness_scale);

            updateParam(paramVec);
            PureData.SendMessage(TOUCHSYMBOL, MESSAGE, pointer, duration, attack, desvol, pitch, chirp, lfndepth, lfnfreq, amdepth, amfreq, richness);
        }
    }

    //sends a trigger message to play the audio
    public void playAudio()
    {
        if (engine_type.Equals("synth"))
        {
            PureData.SendMessage(TOUCHSYMBOL, TRIGGER, BANG);
        }
        else if (engine_type.Equals("sample"))
        {
            
            AudioClip clip = (AudioClip)Resources.Load("samples/"+filename.Remove(filename.Length-4));
            audioSource.Stop();
            audioSource.PlayOneShot(clip);
        }

       
    }

    //changes the xvec type
    public void change_xvecs_type(string type)
    {
        if (type != "unit" && type != "russell")
        {
            throw new System.ArgumentException("type not known, use either unit or russell");
        }
        else
        {
            xvecs_type = type;
        }
    }

    //returns the current xvec setting of the kernelregression class
    public string get_xvecs_type()
    {
        return kr.get_xvecs_type();
    }

    public string get_sound_type()
    {
        return sound_type;
    }

    public string get_engine_type()
    {
        return engine_type;
    }

    public void switch_engines(string type)
    {
        if (type.Equals("synthetic"))
        {
            engine_type = "synth";
        }
        else
        {
            engine_type = "sample";
            if (type.Equals("vocal"))
            {
                sound_type = "voc";
            }
            else if (type.Equals("inference"))
            {
                sound_type = "inf";
            }
        }
    }
      

    //get the x,y coordinates of the specified xvecs type
    public double[][] get_emo_pos(string type = "unit")
    {
        return kr.get_emo_pos(type);
    }

    //returns targets in the same order as the xvecs
    public string[] get_targets()
    {
        return kr.get_targets();
    }

    //scales the richness and checks if thresholds are exceeded
    private float scale_richness(float richness, float richness_scale)
    {
        richness *= richness_scale;

        if (richness > richness_max)
        {
            richness = richness_max;
        }

        else if (richness < richness_min)
        {
            richness = richness_min;
        }

        return richness;
    }

    /// <summary>
    /// Get the nearest emotion from the position on the wheel
    /// </summary>
    /// <param name="posxy">The x,y position</param>
    /// <returns>Name of nearest emotion</returns>
    private string get_nearest_emotion(double[] posxy)
    {

        double[][] emo_pos = kr.get_emo_pos(xvecs_type);
        string[] emotions = kr.get_targets();

        int i = 0;
        double[] distvec = new double[emo_pos.Length];
        foreach(double[] pos in emo_pos)
        {
            distvec[i] = Math.Sqrt(Math.Pow(pos[0] - posxy[0], 2)
                + Math.Pow(pos[1] - posxy[1], 2));
            i++;

        }

        int min_idx = Array.IndexOf(distvec, distvec.Min());
        string nearest_emotion = emotions[min_idx];

        return nearest_emotion;
    }

    private string query(string emotion, string sound_type)
    {
        string file = string.Empty;
        List<string> query_result = new List<string>();

        //get elements matching the request
        for (int i = 0; i < sl.values.Length; i++)
        {
            string emo = sl.values[i].emo;
            string type = sl.values[i].type;

            if (emo.Equals(emotion) && type.Equals(sound_type))
            {
                query_result.Add(sl.values[i].file);
            }
        }

        System.Random random = new System.Random();
        int rnd_idx = random.Next(0, query_result.Count);
        file = query_result[rnd_idx];

        return file;
    }

    //prints par names if debug is set
    private void debug(double[] par)
    {
        int idx = 0;
        foreach (string s in par_names)
        {
            print(s + ": " + par[idx].ToString());
            idx++;
        }
    }

}