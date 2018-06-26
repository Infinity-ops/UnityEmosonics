﻿using System.IO;
using System.Linq;
using UnityEngine;
using System;

public class KernelRegression : MonoBehaviour
{
    private static String[] targets = { "happy", "surprised", "angry", "disgusted", "sad", "calm" };
    private double[][] xvecs = new double[targets.Length][];
    private double[][] pvec = new double[5][];

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

        //initialize struct
        string[] name = new string[] { "dur", "att", "decslope", "pitch", "chirp", "lfnint", "lfnfrq", "amint", "amfreq", "richness" };
        double[] min = new double[] { 0.3, 0.01, -40, 36, -36, 0.0, 0.1, 0.0, 0.1, 0.0 };
        double[] max = new double[] { 2.0, 0.8, 3.0, 72, 36, 1.0, 30.0, 1.0, 30.0, 1.0 };
        string[] func = new string[] { "lin", "exp", "lin", "lin", "cube", "lin", "exp", "lin", "exp", "lin" };
        pa = new parspect_abstract(name, min, max, func);


        //load the csv 
        pvec = load_data();

        foreach (double[] p in pvec)
        {
            print(p);
        }

        //create kernel regression input positions
        for (int i = 0; i < targets.Length; i++)
        {
            xvecs[i] = new double[] { Math.Cos(2 * Math.PI * i / targets.Length), Math.Sin(2 * Math.PI * i / targets.Length + 0.1) };
        }

        /*
        double[] test = Krm(new double[] { 0.7, 0.1 }, 0.7);
        print(test.Length);
        foreach(double t in test)
        {
            print(t);
        } */
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
            if (idx == paramVec.Length - 1) { continue; }

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
            if (idx == paramVec.Length - 1) { continue; }

            if (func[idx] == "lin")
            {
                paramVec_unmapped[idx] = (val - min[idx] / max[idx] - min[idx]);
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

    private double[][] load_data()
    {
        double[][] pvec = new double[][] { new double[] {0.1234981 , 0.13339569, 1.0 , 0.10923002, 1.0, 0.13980813, 0.21005362, 0.19245244, 0.24757245, 0.17806109, 0.74874385},
        new double[] {0.23180798, 0.08560049, 0.42686461, 0.19924696, 0.98922648, 0.62609091, 0.25368131, 0.33101573, 0.00273821, 0.67219538,0.53785216},
        new double[] {0.28984743, 1.0        , 1.0        , 0.0        , 0.22386513, 0.53886225, 0.0, 0.98144621, 0.4292678 , 0.53792187, 0.0 },
        new double[] {0.2218118 , 0.0        , 0.96552386, 0.96221332, 0.0,0.0, 0.0 , 0.0, 0.0 , 0.64299647,0.72607382},
        new double[] {0.68628317, 0.89728318, 0.13770081, 0.43199606, 0.4374264 ,0.0, 0.0 , 0.04111752, 0.0, 1.0, 0.45807017},
        new double[] {0.4768726 , 0.30784232, 0.48337014, 0.44237682, 0.49611336,0.0, 0.0, 0.0, 0.0, 0.5254081 ,0.38428611} };
        return pvec ;
    }

    //Kernel function
    private double Kernel(double[] x, double[] y, double sigma = 1.0)
    {
        double[] diff = x.Select((val, idx) => val - y[idx]).ToArray();
        diff = diff.Select(val => val * val).ToArray(); //basically square element wise
        double sum = diff[0] + diff[1];

        return Math.Exp(-0.5 * sum / Math.Pow(sigma, 2.0));
    }

    //Kernel routine function
    public double[] Krm(double[] xvec, double sigma = 1.0)
    {
        int dim = pvec[0].Length;
        int n = xvecs.Length;
        double[] nom = new double[dim]; //should be zeros(dim)
        Array.Clear(nom, 0, dim); //init array with zeroes
        double den = 0.0;

        for (int i = 0; i < n; i++)
        {
            double temp = Kernel(xvecs[i], xvec, sigma);
            //print(temp);
            //print(xvecs[i][0]);
            nom = nom.Select((val, idx) => val + pvec[i].Select(p => p * temp).ToArray()[idx]).ToArray();
            den += temp;
        }

        return parmap(nom.Select(no => no / den).ToArray());
    }


    // Update is called once per frame
    void Update()
    {

    }
}