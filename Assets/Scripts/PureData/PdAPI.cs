using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that works as API to handle generating the audio
/// </summary>
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

    /// <summary>
    /// Initialize audiosource, PD and KR classes. Load the data based on 
    /// </summary>
    private void Start()
    {
        //dirty hack to make the audiosource work
        SceneManager.LoadScene(0);

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1f;

        kr = gameObject.AddComponent<KernelRegression>();
        PureData.OpenPatch("abstractlatest");

        //choose which JsonLoader to use
        if (engine_type == "sample")
        {
            JL = new JsonLoader(file);
        }
        else if (engine_type == "synth")
        {
            JL = new JsonLoader();
        }

    }

    // Use this for initialization?
    void Awake()
    {

    }

    /// <summary>
    /// Function to update the parameters for the audio generation with the paramVec from the kernel regression
    /// </summary>
    /// <param name="paramVec">Mapped paramVec array from the kernel regression</param>
    void updateParam(double[] paramVec)
    {

        pointer = 1.0f;
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

     /// <summary>
     /// This function is an interface to update the parameters for the audio generation. For the sample type, it sets the according
     /// filename to be played, for the synth type it updated the parameters for pd
     /// </summary>
     /// <param name="posxy">x,y-position on the wheel</param>
     /// <param name="richness_scale">Scaling parameter for the richness</param>
    public void changeValue(double[] posxy, float richness_scale = 1.0f)
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

            //scale richness
            richness = scale_richness(richness, richness_scale);

            updateParam(paramVec);
            PureData.SendMessage(TOUCHSYMBOL, MESSAGE, pointer, duration, attack, desvol, pitch, chirp, lfndepth, lfnfreq, amdepth, amfreq, richness);
        }
    }

    /// <summary>
    /// The function to play the sound. It will send either a message to pd, or plays an audio clip from the resources according
    /// to the engine type
    /// </summary>
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

    /// <summary>
    /// This functions sets the xvecs type to the string passed to it
    /// </summary>
    /// <param name="type">Type to change, either "unit" or "russell"</param>
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

    /// <summary>
    /// Returns current xvecs_type
    /// </summary>
    /// <returns>String with the current xvecs_type</returns>
    public string get_xvecs_type()
    {
        return kr.get_xvecs_type();
    }

    /// <summary>
    /// Returns the current sound type used
    /// </summary>
    /// <returns>String with the sound type, either "voc" or "inf"</returns>
    public string get_sound_type()
    {
        return sound_type;
    }

    /// <summary>
    /// Returns the current engine type
    /// </summary>
    /// <returns>String with the engine type, either "synth" or "sample"</returns>
    public string get_engine_type()
    {
        return engine_type;
    }

    /// <summary>
    /// Switch the sound engine type and sound type to the one specified in the string passed
    /// </summary>
    /// <param name="type">String with the enigne type to use. Either "synthetic" or "vocal" or "inference"</param>
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
      
    /// <summary>
    /// Function to get the x,y-position of the ankerpoints according to the current type
    /// </summary>
    /// <param name="type">Type of the xvecs to get the positions from. Either "unit" or "russell"</param>
    /// <returns></returns>
    public double[][] get_emo_pos(string type = "unit")
    {
        return kr.get_emo_pos(type);
    }

    /// <summary>
    /// Function to get the emotion names. The order of the names is the same as in the xvecs array
    /// </summary>
    /// <returns>String array with the emotion names</returns>
    public string[] get_targets()
    {
        return kr.get_targets();
    }

    //scales the richness and checks if thresholds are exceeded
    /// <summary>
    /// Function to scale the richenss parameter by a scale parameter. The richness can be scaled only to the
    /// min and max richness values defined in this class
    /// </summary>
    /// <param name="richness">The richness value</param>
    /// <param name="richness_scale">The scale factor</param>
    /// <returns>Returns the scaled richness</returns>
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

    /// <summary>
    /// Performs a query and samples a random file name from the resulting set of filenames 
    /// </summary>
    /// <param name="emotion">The name of the emotion to query</param>
    /// <param name="sound_type">The sound type, either "voc" or "inf" to query</param>
    /// <returns>Randomly sampled filename to play according to the query</returns>
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

}