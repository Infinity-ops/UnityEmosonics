using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class GameControl : MonoBehaviour
{
    private bool startup = true;

    public string visualization;

    public Color favorite1Color;
    public Color favorite2Color;
    public Color favorite3Color;
    public Color favorite4Color;

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
        if (startup)
        {
            Load();
            startup = false;
        }

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

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        Save();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();

        SurrogateSelector surrogateSelector = new SurrogateSelector();
        Vector2SerializationSurrogate vector2SS = new Vector2SerializationSurrogate();
        Vector3SerializationSurrogate vector3SS = new Vector3SerializationSurrogate();
        ColorSerializationSurrogate colorSS = new ColorSerializationSurrogate();

        surrogateSelector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), vector2SS);
        surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3SS);
        surrogateSelector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), colorSS);

        bf.SurrogateSelector = surrogateSelector;

        FileStream file = File.Create(Application.persistentDataPath + "/EmoSonicsSettings.dat");

        PlayerSettings settings = new PlayerSettings();

        settings.visualization = visualization;

        settings.Favorite1Color = favorite1Color;
        settings.Favorite2Color = favorite2Color;
        settings.Favorite3Color = favorite3Color;
        settings.Favorite4Color = favorite4Color;

        settings.Favorite1Pos = favorite1Pos;
        settings.Favorite2Pos = favorite2Pos;
        settings.Favorite3Pos = favorite3Pos;
        settings.Favorite4Pos = favorite4Pos;
        settings.Favorite1Sound = favorite1Sound;
        settings.Favorite2Sound = favorite2Sound;
        settings.Favorite3Sound = favorite3Sound;
        settings.Favorite4Sound = favorite4Sound;

        bf.Serialize(file, settings);

        file.Close();
    }

    public void Load()
    {

        Debug.Log(Application.persistentDataPath + "/EmoSonicsSettings.dat");

        Debug.Log(File.Exists(Application.persistentDataPath + "/EmoSonicsSettings.dat"));

        if (File.Exists(Application.persistentDataPath + "/EmoSonicsSettings.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            SurrogateSelector surrogateSelector = new SurrogateSelector();
            Vector2SerializationSurrogate vector2SS = new Vector2SerializationSurrogate();
            Vector3SerializationSurrogate vector3SS = new Vector3SerializationSurrogate();
            ColorSerializationSurrogate colorSS = new ColorSerializationSurrogate();

            surrogateSelector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), vector2SS);
            surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3SS);
            surrogateSelector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), colorSS);

            bf.SurrogateSelector = surrogateSelector;

            FileStream file = File.Open(Application.persistentDataPath + "/EmoSonicsSettings.dat", FileMode.Open);

            PlayerSettings settings = (PlayerSettings)bf.Deserialize(file);

            file.Close();

            visualization = settings.visualization;

            favorite1Color = settings.Favorite1Color;
            favorite2Color = settings.Favorite2Color;
            favorite3Color = settings.Favorite3Color;
            favorite4Color = settings.Favorite4Color;

            favorite1Pos = settings.Favorite1Pos;
            favorite2Pos = settings.Favorite2Pos;
            favorite3Pos = settings.Favorite3Pos;
            favorite4Pos = settings.Favorite4Pos;
            favorite1Sound = settings.Favorite1Sound;
            favorite2Sound = settings.Favorite2Sound;
            favorite3Sound = settings.Favorite3Sound;
            favorite4Sound = settings.Favorite4Sound;
        }
        else
        {
            visualization = "smiley";
            favorite1Color = new Color(1.0F, 1.0F, 1.0F);
            favorite2Color = new Color(1.0F, 1.0F, 1.0F);
            favorite3Color = new Color(1.0F, 1.0F, 1.0F);
            favorite4Color = new Color(1.0F, 1.0F, 1.0F);
        }
    }

    [Serializable]
    public class PlayerSettings
    {
        public string visualization;
        private Color favorite1Color;
        public Color Favorite1Color
        {
            get { return favorite1Color; }
            set { favorite1Color = value; }
        }
        private Color favorite2Color;
        public Color Favorite2Color
        {
            get { return favorite2Color; }
            set { favorite2Color = value; }
        }
        private Color favorite3Color;
        public Color Favorite3Color
        {
            get { return favorite3Color; }
            set { favorite3Color = value; }
        }
        private Color favorite4Color;
        public Color Favorite4Color
        {
            get { return favorite4Color; }
            set { favorite4Color = value; }
        }
        private Vector3 favorite1Pos;
        public Vector3 Favorite1Pos
        {
            get { return favorite1Pos; }
            set { favorite1Pos = value; }
        }
        private Vector3 favorite2Pos;
        public Vector3 Favorite2Pos
        {
            get { return favorite2Pos; }
            set { favorite2Pos = value; }
        }
        private Vector3 favorite3Pos;
        public Vector3 Favorite3Pos
        {
            get { return favorite3Pos; }
            set { favorite3Pos = value; }
        }
        private Vector3 favorite4Pos;
        public Vector3 Favorite4Pos
        {
            get { return favorite4Pos; }
            set { favorite4Pos = value; }
        }
        private Vector2 favorite1Sound;
        public Vector2 Favorite1Sound
        {
            get { return favorite1Sound; }
            set { favorite1Sound = value; }
        }
        private Vector2 favorite2Sound;
        public Vector2 Favorite2Sound
        {
            get { return favorite2Sound; }
            set { favorite2Sound = value; }
        }
        private Vector2 favorite3Sound;
        public Vector2 Favorite3Sound
        {
            get { return favorite3Sound; }
            set { favorite3Sound = value; }
        }
        private Vector2 favorite4Sound;
        public Vector2 Favorite4Sound
        {
            get { return favorite4Sound; }
            set { favorite4Sound = value; }
        }
    }
}
