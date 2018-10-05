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
    private string filename;
    private string[] filenames;
    
    public JsonLoader(string file)
    {
        //define the data path and data files
        //ATTENTION: the file names for android (JsonFiles) must be hardcoded in filenams variable
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            res_dir = "/Resources/data/sample";
            path = Application.streamingAssetsPath + res_dir;
            dir = new DirectoryInfo(path);
            Files = dir.GetFiles("*.json");
        }

        else if (Application.platform == RuntimePlatform.Android)
        {
            res_dir = "/Resources/data/sample/";
            path = Application.streamingAssetsPath + res_dir;
            filename = path + file;
            filenames = new string[] { filename };
            Debug.Log("##########FILENAME: " + filename);
        }

    }


    public SampleList Load_samples_info()
    {
        string jsonString = string.Empty;
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            jsonString = this.LoadDataEditor();
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            jsonString = this.LoadDataAndroid();
        }

        SampleList sl = JsonLoader.CreateFromJson_sample(jsonString);
        
        return sl;

    }

    public JsonLoader()
    {
        //define the data path and data files
        //ATTENTION: the file names for android (JsonFiles) must be hardcoded in filenams variable
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            res_dir = "/Resources/data";
            path = Application.dataPath + res_dir;
            dir = new DirectoryInfo(path);
            Files = dir.GetFiles("*.json");
        }

        else if (Application.platform == RuntimePlatform.Android)
        {
            res_dir = "/Resources/data/";
            path = Application.streamingAssetsPath + res_dir;
            filenames = new string[] {path+"data1.json", path+"data2.json"}; //must be hardcoded
        }

    }

    public double[][] Load_pvec()
    {
        //load json data into a value list
        string jsonString = string.Empty;
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            jsonString = this.LoadDataEditor();
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            jsonString = this.LoadDataAndroid();
        }

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
            pvec[i] = Array.ConvertAll(tmp.Split(','), Double.Parse);

        }

        return pvec;
    }

    public static SampleList CreateFromJson_sample(string jsonString)
    {
        return JsonUtility.FromJson<SampleList>("{\"values\":" + jsonString + "}");
    }

    public static ValueList CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<ValueList>("{\"values\":" + jsonString + "}");
    }

    //load the json Data
    public string LoadDataEditor()
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

    //load the json Data on Android device
    public string LoadDataAndroid()
    {
        
        string jsonString = string.Empty;

        int i = 0;
        foreach(string file in filenames)
        {
            WWW www = new WWW(file);
            if (i == 0)
            {
                jsonString = www.text;
            }

            else
            {
                //remove last char that is a "]" and ad an "," so that the strings can be concatenated
                string tmpstring = string.Concat(jsonString.Remove(jsonString.Length - 1), ",");
                jsonString = string.Concat(tmpstring, www.text.Remove(0, 1));
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

[System.Serializable]
public class SampleList
{
    public SampleParameter[] values;
}

[System.Serializable]
public class SampleParameter
{
    public string emo, type, id, file;
}
