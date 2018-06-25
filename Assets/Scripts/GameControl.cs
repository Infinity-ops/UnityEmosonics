using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameControl : MonoBehaviour
{

	public string visualization = "smiley";

	public Color favorite1_color = new Color(1.0F, 1.0F, 1.0F);
	public Color favorite2_color = new Color(1.0F, 1.0F, 1.0F);
	public Color favorite3_color = new Color(1.0F, 1.0F, 1.0F);
	public Color favorite4_color = new Color(1.0F, 1.0F, 1.0F);

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
