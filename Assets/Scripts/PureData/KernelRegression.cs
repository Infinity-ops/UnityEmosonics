using System.IO;
using System.Linq;
using UnityEngine;
using System;

/*
 * TODO: Find a way on how to deal with a sigma that would get too small
 * Debug by checking if param vector is exactly the emotion prototype when they are near to each other and small sigma
 * Store hardcoded pvecs in config file AND/OR load directly from .json?
 */

public class KernelRegression : MonoBehaviour
{
    private static String[] targets = { "happy", "surprised", "angry", "disgusted", "sad", "calm" };
    private double[] emotion_angles = { 11, 80, 172, 200, 236, 328 };
    private double[][] xvecs = new double[targets.Length][];
    private double[][] xvecs_unit = new double[targets.Length][];
    private double[][] xvecs_russell = new double[targets.Length][];
    private double[][] pvec = new double[5][]; //magic number because pvec is hardcoded for now (but from a working kernel regression example)

    //struct object that contains all the parspect_abstract values
    struct parspect_abstract
    {
        string[] name;
        double[] min;
        double[] max;
        string[] func;

        public parspect_abstract(string[] name, double[] min, double[] max, string[] func)
        {
            this.name = name;
            this.min = min;
            this.max = max;
            this.func = func;
        }

        public string[] get_name() { return this.name; }
        public double[] get_min() { return this.min; }
        public double[] get_max() { return this.max; }
        public string[] get_func() { return this.func; }

    };
    private parspect_abstract pa;

    /*
    private object parspect_abstract2 = new object[][] { new object[] { "dur", 0.3, 2.0, "lin", 0.4,  "secs" },
                                                        new object[] { "att", 0.01, 0.8, "exp", 0.4, "%" },
                                                        new object[] {"decslope", -40, 3, "lin", -12, "amp/dur"},
                                                        new object[] { "pitch", 36, 72, "lin", 50, "midinone" },
                                                        new object[] {"chirp", -36, 36, "cube", 0, "semitones/dur" },
                                                        new object[] {"lfnint", 0.0, 1.0, "lin", 0.0, "rate" },
                                                        new object[] {"lfnfrq", 0.1, 30, "exp", 0.1, "Hz"},
                                                        new object[] {"amint", 0.0, 1.0, "lin", 0.0, "rate"},
                                                        new object[] {"amfreq", 0.1, 30, "exp", 0.1, "Hz" },
                                                        new object[] {"richness", 0.0, 1.0, "lin", 0.0, "%" }}; */
    /*
        private object parspect_vocal = new object[][]    { new object[] { "dur", 0.3, 2.0, "lin", 0.4, "secs"},
                                                            new object[] { "att", 0.001, 0.5, "exp", 0.001, "secs"},
                                                            new object[] {"decslope", -40, 3, "lin", -12, "dB/rm time"},
                                                            new object[] { "amint",  0, 1, "lin", 0, "intensity"},
                                                            new object[] {"amfreq", 0.1, 10, "exp", 0.1, "Hz"},
                                                            new object[] {"pitch", 36, 72, "lin", 50, "midinote"},
                                                            new object[] {"pitch", 36, 72, "lin", 50, "midinote"},
                                                            new object[] {"pitch", 36, 72, "lin", 50, "midinote"},
                                                            new object[] {"lfnint", 0, 1., "lin", 0, "rel. pitch" },
                                                            new object[] {"vowel", 0, 4, "lin", 2.5, "uoaei"},
                                                            new object[] {"voweldiff", -2.5, 2.5, "lin", 0, "delta" },
                                                            new object[] {"bright", 0.2, 1, "lin", 0.5, "arb.u." } }; */


    // Use this for initialization
    // On start: load csv data containing pattern into array
    void Awake()
    {
        JsonLoader jl = new JsonLoader();
        string[] test = jl.LoadData();
        print("FILE LOADED");
        ValueList tj = JsonLoader.CreateFromJson(test[0]);
        print(tj.values[0].snd);


        //initialize struct
        string[] name = new string[] { "dur", "att", "decslope", "pitch", "chirp", "lfnint", "lfnfrq", "amint", "amfreq", "richness" };
        double[] min = new double[] { 0.3, 0.01, -40, 36, -36, 0.0, 0.1, 0.0, 0.1, 0.0 };
        double[] max = new double[] { 2.0, 0.8, 3.0, 72, 36, 1.0, 30.0, 1.0, 30.0, 1.0 };
        string[] func = new string[] { "lin", "exp", "lin", "lin", "cube", "lin", "exp", "lin", "exp", "lin" };
        pa = new parspect_abstract(name, min, max, func);


        //load the csv 
        pvec = load_data();

        //create kernel regression input positions for unit distribution and russels angles
        double phase_offset = 0.1;
        int[] origin = new int[] { 0, 0 };
        for (int i = 0; i < targets.Length; i++)
        {
            xvecs_unit[i] = new double[] { Math.Cos(2 * Math.PI * i / targets.Length + phase_offset),
                Math.Sin(2 * Math.PI * i / targets.Length + phase_offset) };

            xvecs_russell[i] = new double[] {origin[0]+Math.Cos((emotion_angles[i]*Math.PI)/180),
            origin[1]+Math.Sin((emotion_angles[i]*Math.PI)/180)};
        }

    }

    private double[] parmap(double[] paramVec)
    {
        double[] paramVec_mapped = new double[paramVec.Length];

        double[] min = pa.get_min();
        double[] max = pa.get_max();
        string[] func = pa.get_func();

        int idx = 0;
        foreach (double val in paramVec)
        {
            if (idx == paramVec.Length - 1)
            {
                break;
            }  //stop iteration because we won't need the last value

            if (func[idx] == "lin")
            {
                paramVec_mapped[idx] = min[idx] + (max[idx] - min[idx]) * val;
            }

            else if (func[idx] == "exp")
            {
                paramVec_mapped[idx] = min[idx] * Math.Exp(Math.Log(max[idx] / min[idx]) * val);
            }

            else
            {

                paramVec_mapped[idx] = Math.Pow(2 * val - 1, 3.0) * max[idx];

            }
            idx++;
        }

        return paramVec_mapped;
    }

    private double[] parunmap(double[] paramVec)
    {
        double[] paramVec_unmapped = new double[paramVec.Length];

        double[] min = pa.get_min();
        double[] max = pa.get_max();
        string[] func = pa.get_func();

        int idx = 0;
        foreach (double val in paramVec)
        {
            if (idx == paramVec.Length - 1) { break; }

            if (func[idx] == "lin")
            {
                paramVec_unmapped[idx] = (val - min[idx]) / (max[idx] - min[idx]);
            }

            else if (func[idx] == "exp")
            {
                paramVec_unmapped[idx] = Math.Log(val / min[idx]) / Math.Log(max[idx] / min[idx]);
            }

            else
            {
                if (val < 0)
                {
                    paramVec_unmapped[idx] = (Math.Pow(-(-val / 26.0), (1 / 3.0)) + 1) / 2;
                }
                else
                {
                    paramVec_unmapped[idx] = (Math.Pow((val / 26.0), (1 / 3.0)) + 1) / 2;
                }
            }
            idx++;
        }

        return paramVec_unmapped;
    }

    //Load the data into the pvecs array
    //use a hardcoded example at first
    //this order: "happy", "surprised", "angry", "disgusted", "sad", "calm"
    private double[][] load_data()
    {
        /*
        double[][] pvec = new double[][] { new double[] {0.1234981 , 0.13339569, 1.0 , 0.10923002, 1.0, 0.13980813, 0.21005362, 0.19245244, 0.24757245, 0.17806109, 0.74874385},
        new double[] {0.23180798, 0.08560049, 0.42686461, 0.19924696, 0.98922648, 0.62609091, 0.25368131, 0.33101573, 0.00273821, 0.67219538,0.53785216},
        new double[] {0.28984743, 1.0        , 1.0        , 0.0        , 0.22386513, 0.53886225, 0.0, 0.98144621, 0.4292678 , 0.53792187, 0.0 },
        new double[] {0.2218118 , 0.0        , 0.96552386, 0.96221332, 0.0,0.0, 0.0 , 0.0, 0.0 , 0.64299647,0.72607382},
        new double[] {0.68628317, 0.89728318, 0.13770081, 0.43199606, 0.4374264 ,0.0, 0.0 , 0.04111752, 0.0, 1.0, 0.45807017},
        new double[] {0.4768726 , 0.30784232, 0.48337014, 0.44237682, 0.49611336,0.0, 0.0, 0.0, 0.0, 0.5254081 ,0.38428611} };*/

        double[][] pvec = new double[][] { new double[] {0.3142107054688759, 0.9972524716586859, 0.1447865695017771, 0.2817567069071276, 1.0, 0.7290626543532572, 0.8849599208126919, 0.7063145595322309, 0.8251369002936291, 0.0},
        new double[] {0.0, 0.6880295628306545, 0.6714753548561211, 0.49118351484592326, 1.0, 0.4311902709456575, 0.8447215975251929, 0.6136919352118451, 0.7334224386276923, 0.08414672002236959},
        new double[] {0.35879197809451524, 0.5545366483878481, 0.9564953946370289, 0.5247428555000556, 0.3419773898619578, 0.3387273024669967, 0.0, 0.07666472517061476, 0.2774559574483457, 0.7315150432546706},
        new double[] {1.0, 0.8250973419878893, 0.4444957364782214, 0.6824873714756801, 0.0, 0.36476511958415403, 0.7579932592767031, 0.11306319369219678, 0.35668728613899225, 0.0},
        new double[] {0.6558921818532458, 0.9361527551390026, 0.0, 0.9109757922703378, 0.16930383779314395, 0.06740760264974206, 0.1878754667825457, 0.03006393892953673, 0.3735653152468994, 0.12285541458296113},
        new double[] { 0.40997116993473726, 0.7745261753026569, 0.5051231483546325, 0.27058027972647886, 0.38013525839677365, 0.0, 0.45039442613548336, 0.0, 0.0, 0.009538783881069685 } };

        return pvec;
    }

    //Kernel function
    //x = pvec. y = coordinate on circle
    private double Kernel(double[] x, double[] y, double sigma = 1.0)
    {
        print(x[0].ToString() + " - " + x[1].ToString() + " this is the xvec");
        print(y[0].ToString() + " - " + y[1].ToString() + " this is the coordinate");
        double[] diff = x.Select((val, idx) => val - y[idx]).ToArray();
        //print(diff[0].ToString() + " - " + diff[1].ToString() + " this is the diff");
        diff = diff.Select(val => val * val).ToArray(); //basically square element 
        double sum = diff[0] + diff[1];

        //sum *= 1000;

        //print(Math.Exp(-0.5 * sum / Math.Pow(sigma, 2.0)).ToString()+" - " + sum.ToString());
        return Math.Exp(-0.5 * sum / Math.Pow(sigma, 2.0));
    }

    //Kernel routine function
    public double[] Krm(double[] xvec, double sigma = 1.0, string xvecs_type = "unit", bool debug = false)
    {
        //set the ankerpoints
        if (xvecs_type == "unit") { xvecs = xvecs_unit; }
        else if (xvecs_type == "russell") { xvecs = xvecs_russell; }

        int nr_synth_parameters = pvec[0].Length;
        int nr_emo_prototypes = xvecs.Length;
        double[] nom = new double[nr_synth_parameters];
        Array.Clear(nom, 0, nr_synth_parameters); //init array with zeroes
        print("sigma" + sigma.ToString());
        double den = 0.0;
        print("---");
        for (int i = 0; i < nr_emo_prototypes; i++)
        {
            print(i);
            double temp = Kernel(xvecs[i], xvec, sigma);
            //print("temp: " + temp.ToString());
            //nom = nom.Select((val, idx) => val + pvec[i].Select(p => p * temp).ToArray()[idx]).ToArray();

            double[] weighted_parameters_for_emotion_i = pvec[i].Select(p => p * temp).ToArray();
            nom = nom.Select((val, idx) => val + weighted_parameters_for_emotion_i[idx]).ToArray();
            den += temp;
        }
        print("nom end:" + nom[0].ToString());
        double[] krm_parvec = nom.Select(no => no / den).ToArray();

        if (debug)
        {
            return krm_parvec;
        }
        else
        {
            return parmap(krm_parvec);
        }

    }

    public void debug(double[] paramVec, double[] xy)
    {
        double sigma = 0.03;
        //compare distances
        double[] dist_vec = new double[6];
        int idx = 0;
        foreach (double[] xv in xvecs)
        {
            //print(xv);
            dist_vec[idx] = Math.Sqrt(Math.Pow(xy[0] - xv[0], 2)
                + Math.Pow(xy[1] - xv[1], 2));
            idx++;
        }



        int closest_idx = Array.IndexOf(dist_vec, dist_vec.Min());
        double[] closes_emotion = xvecs[closest_idx];

        double[] debug_vec = Krm(closes_emotion, sigma, get_xvecs_type(), true);

        //print distances
        idx = 0;
        foreach (double val in debug_vec)
        {
            //print(Math.Abs(val - paramVec[idx]));
            idx++;
        }
        //print("----");
    }

    //get the type of the ankerpoints, either unit distributed or from russell's angles
    public string get_xvecs_type()
    {
        if (xvecs == xvecs_unit)
        {
            return "unit";
        }
        else
        {
            return "russell";
        }
    }

    //returns the emotion positions on the wheel
    public double[][] get_emo_pos(string xvecs_type = "unit")
    {
        if (xvecs_type == "unit")
        {
            return xvecs_unit;
        }
        else if (xvecs_type == "russell")
        {
            return xvecs_russell;
        }
        else
        {
            throw new System.ArgumentException("xvec type not defined", "xvecs_type");
        }

    }

    //return vector of all emotional targets (for example sad, happy, disgusted, ...)
    public string[] get_targets()
    {
        return targets;
    }

}