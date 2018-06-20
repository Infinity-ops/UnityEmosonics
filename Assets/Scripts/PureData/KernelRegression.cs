using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System;

public class KernelRegression : MonoBehaviour {
    private static String[] targets = {"happy", "surprised", "angry", "disgusted", "sad", "calm"};
    private double[][] xvecs = new double[targets.Length][];
    private double[][] pvec = new double[5][];

	// Use this for initialization
    // On start: load csv data containing pattern into array
	void Start () {

        //load the csv 
        pvec = load_data();

        //create kernel regression input positions
        for(int i=0; i<targets.Length; i++)
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

    //Load the data into the pvecs array
    private double[][] load_data()
    {
        /*Load data from resource folder into a list*/
        string res_dir = "/Resources/data";
        string path = Application.dataPath + res_dir;
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] Files = dir.GetFiles("*.csv");

        DataTable csvData;
        DataTable df = new DataTable();

        int count = 0;
        foreach (FileInfo file in Files)
        {
            csvData = GetDataTableFromCSVFile(file.ToString());
            if (count == 0)
            {
                df = csvData;
            }
            else
            {
                df.Merge(csvData);
            }

            count++;
        }

        DataRow[] result =  df.Select("submit='1' AND uid='1001' AND snd='abstract' AND run='1'");

        double[][] pvec = new double[result.Count()][];

        for(int i=0; i < result.Count(); i++)
        {
            String tmp = result[i][7].ToString();
            tmp = tmp.Split('[')[1].Split(']')[0];
            pvec[i] = Array.ConvertAll(tmp.Split(','), Double.Parse);
        }

        /*
        double[][] pvecs = new double[targets.Length][];
        int counter = 0;
        foreach(String t in targets)
        {
            if(result[])
            pvecs[counter] = ;
            counter++;
        } */


        return pvec;
    }

    //Kernel function
    private double Kernel(double[] x, double[] y, double sigma=1.0)
    {
        double[] diff = x.Select((val, idx) => val - y[idx]).ToArray();
        diff =  diff.Select(val => val*val).ToArray(); //basically square element wise
        double sum = diff[0] + diff[1];

        return Math.Exp(-0.5*sum/Math.Pow(sigma,2.0));
    }

    //Kernel routine function
    public double[] Krm(double[] xvec, double sigma=1.0)
    {
        int dim = pvec[0].Length;
        int n = xvecs.Length;
        double[] nom = new double[dim]; //should be zeros(dim)
        Array.Clear(nom, 0, dim); //init array with zeroes
        double den = 0.0;

        for(int i=0; i<n; i++)
        {
            double temp = Kernel(xvecs[i], xvec, sigma);
            //print(temp);
            //print(xvecs[i][0]);
            nom = nom.Select((val,idx) => val + pvec[i].Select(p => p*temp).ToArray()[idx]).ToArray();
            den += temp;
        }

        return nom.Select(no => no/den).ToArray();
    }

    //Function to load scv data
    private static DataTable GetDataTableFromCSVFile(string csv_file_path)
    {
        DataTable csvData = new DataTable();

        try
        {
            using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;
                string[] colFields = csvReader.ReadFields();

                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }

                    csvData.Rows.Add(fieldData);
                }
            }
        }
        catch (Exception ex)
        {
        }

        return csvData;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
