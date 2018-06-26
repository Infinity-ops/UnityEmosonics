using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameControl : MonoBehaviour
{

	public string visualization = "smiley";

	public Color favorite1Color = new Color(1.0F, 1.0F, 1.0F);
	public Color favorite2Color = new Color(1.0F, 1.0F, 1.0F);
	public Color favorite3Color = new Color(1.0F, 1.0F, 1.0F);
	public Color favorite4Color = new Color(1.0F, 1.0F, 1.0F);

	public Vector3 favorite1Pos;
	public Vector3 favorite2Pos;
	public Vector3 favorite3Pos;
	public Vector3 favorite4Pos;
	public Vector2 favorite1Sound;
	public Vector2 favorite2Sound;
	public Vector2 favorite3Sound;
	public Vector2 favorite4Sound;
	public Vector3 crosshairPosition;
	public Vector2 soundPosition;
	public Vector3 lastCrosshairPos;
	public Vector2 lastSoundPosition;

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
