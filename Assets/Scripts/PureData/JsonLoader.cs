using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class JsonLoader
{
    private string res_dir, path;
    private DirectoryInfo dir;
    private FileInfo[] Files;

    public JsonLoader()
    {
        //define the data path and data files
        res_dir = "/Resources/data";
        path = Application.dataPath + res_dir;
        dir = new DirectoryInfo(path);
        Files = dir.GetFiles("*.json");
    }

    public double[][] Load_pvec()
    {
        //load json data into a value list
        string jsonString = this.LoadData();
        ValueList vl = JsonLoader.CreateFromJson(jsonString);
        List<string> parvec = new List<string>();

        //filter the data
        for (int i = 0; i < vl.values.Length; i++)
        {

            string submit = vl.values[i].submit;
            string uid = vl.values[i].uid;
            string snd = vl.values[i].snd;
            string run = vl.values[i].run;

            if (submit.Equals("1") && uid.Equals("1001") && snd.Equals("abstract")
                && run.Equals("1"))
            {
                parvec.Add(vl.values[i].parvec);
            }
        }

        //transform parvec to actual double values
        double[][] pvec = new double[parvec.Count][];

        for (int i = 0; i < parvec.Count; i++)
        {
            String tmp = parvec[i];
            tmp = tmp.Split('[')[1].Split(']')[0];
            Debug.Log(tmp);
            pvec[i] = Array.ConvertAll(tmp.Split(','), Double.Parse);

        }

        return pvec;
    }

    public static ValueList CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<ValueList>("{\"values\":" + jsonString + "}");
    }

    //load the json Data
    public string LoadData()
    {
        string jsonString = string.Empty;

        int i = 0;
        foreach (FileInfo file in Files)
        {
            if (i == 0)
            {
                jsonString = File.ReadAllText(file.ToString());
            }
            
            else
            {
                //remove last char that is a "]" and ad an "," so that the strings can be concatenated
                string tmpstring = string.Concat(jsonString.Remove(jsonString.Length - 1), ",");
                jsonString = string.Concat(tmpstring, File.ReadAllText(file.ToString()).Remove(0, 1));
            }
            
            i++;
        }
        return jsonString;
    }

}

[System.Serializable]
public class ValueList
{
    public AudioParameter[] values;
}

[System.Serializable]
public class AudioParameter {

    //Define audio Parameters
    public string uid, snd, run, time, target, generation, logsigma, submit, parvec;
}

