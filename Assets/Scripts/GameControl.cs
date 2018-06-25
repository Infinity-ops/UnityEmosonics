using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameControl : MonoBehaviour
{

	public string visualization = "smiley";

    public static GameControl control;

    // Use this for initialization
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
			Destroy(gameObject);
        }
    }

	public void Save()
	{
		FileStream file = File.Create(Application.persistentDataPath + "/EmoSonicsSettings.dat");

		file.Close();
	}

	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/EmoSonicsSettings.dat"))
		{
			FileStream file = File.Open(Application.persistentDataPath + "/EmoSonicsSettings.dat", FileMode.Open);

			file.Close();
		}
	}
}
