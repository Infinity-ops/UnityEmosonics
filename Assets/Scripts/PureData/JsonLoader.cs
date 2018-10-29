using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

/**
 * loads json files based on platform; used for loading
 * emotion anchor points
*/

    /// <summary>
    /// Class that is used to load json files based on platform. Either the sample files are loaded or the parvec data based on
    /// which class constructor is used.
    /// </summary>
public class JsonLoader
{
    private string res_dir, path;
    private DirectoryInfo dir;
    private FileInfo[] Files;
    private string filename;
    private string[] filenames;
    

    /// <summary>
    /// Initializes the path and directory used to load the sample data
    /// </summary>
    /// <param name="file">Name of the file with the sample data</param>
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

    /// <summary>
    /// Function that loads the info from the json file into a SampleList class
    /// </summary>
    /// <returns>SampleList class that contains the sample information from the json file</returns>
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

    /// <summary>
    /// Initializes the path and directory used to load the parvec data
    /// </summary>   
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

/// <summary>
/// FUnction that loads the pvec values from the json file
/// </summary>
/// <returns>Returns array with parvec values</returns>
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

    /// <summary>
    /// Helper Function to load the json values in the SampleList class
    /// </summary>
    /// <param name="jsonString">The parsed json string containing data of the samples</param>
    /// <returns>Returns a SampleList class</returns>
    public static SampleList CreateFromJson_sample(string jsonString)
    {
        return JsonUtility.FromJson<SampleList>("{\"values\":" + jsonString + "}");
    }


    /// <summary>
    /// Helper Function to load the json values in the ValueList class
    /// </summary>
    /// <param name="jsonString">The parsed json string containing data of the parvec</param>
    /// <returns>Returns a ValueLIst class</returns>
    public static ValueList CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<ValueList>("{\"values\":" + jsonString + "}");
    }

    /// <summary>
    /// Function to parse the json file when the used platform is the Editor
    /// </summary>
    /// <returns>Returns the parsed json string</returns>
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

    /// <summary>
    /// Function to parse the json file when the used platform is Android
    /// </summary>
    /// <returns>Returns the parsed json string</returns>
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

/// <summary>
/// Helper class for serializing the audio parameters
/// </summary>
[System.Serializable]
public class ValueList
{
    public AudioParameter[] values; /**< list of audio parameter values */
}

/// <summary>
/// Class for serializing the audio parameters
/// </summary>
[System.Serializable]
public class AudioParameter {

    //Define audio Parameters
    public string uid; /**< uid parameter for pd model */
    public string snd; /**< snd parameter for pd model */
    public string run; /**< run parameter for pd model */
    public string time; /**< time parameter for pd model */
    public string target; /**< target parameter for pd model */
    public string generation; /**< generation parameter for pd model */
    public string logsigma; /**< logsigma parameter for pd model */
    public string submit; /**< submit parameter for pd model */
    public string parvec; /**< parvec parameter for pd model */
}

/// <summary>
///  Helper class for serializing the sample information
/// </summary>
[System.Serializable]
public class SampleList
{
    public SampleParameter[] values;
}

/// <summary>
/// Class for serializing the sample informations
/// </summary>
[System.Serializable]
public class SampleParameter
{
    public string emo, type, id, file;
}
