using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonLoader
{
    private string res_dir, path;
    private DirectoryInfo dir;
    private FileInfo[] Files;

    public void Load_pvec()
    {
        //maybe concatenate already json String?
        string[] jsonString = this.LoadData();



    }

    public JsonLoader()
    {
        //define the data path and data files
        res_dir = "/Resources/data";
        path = Application.dataPath + res_dir;
        dir = new DirectoryInfo(path);
        Files = dir.GetFiles("*.json");
    }

    public static ValueList CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<ValueList>("{\"values\":" + jsonString + "}");
    }

    //load the json Data
    public string[] LoadData()
    {
        string[] jsonString = new string[Files.Length];

        int i = 0;
        foreach (FileInfo file in Files)
        {
            jsonString[i] = File.ReadAllText(file.ToString());
            i++;
        }
        Debug.Log(jsonString[0]);
        Debug.Log(jsonString.Length);
        return jsonString;
    }

}

[System.Serializable]
public class ValueList
{
    public AudioParameter[] values;
}

[System.Serializable]
public class AudioParameter
{

    //Define audio Parameters
    public string uid, snd, run, time, target, generation, logsigma, submit, parvec;
}