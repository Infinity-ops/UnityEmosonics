using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

/**
 * saves game and communication tool settings and data -
 * makes all data accessible and persistent across all
 * classes and functions
 */
public class GameControl : MonoBehaviour
{
    private bool startup = true; /**< toggle variable if app is just started up */

    public bool onBoardingFinished = false; /**< Toggle variable if onboarding isn't finished */

    public int visualization; /**< toggle variable for point label visualization*/
    public int representation; /**< toggle variable for russel or uniform representation */
    public int soundSetting; /**< what sound producing method to pass to backernd */

    public Color favorite1Color; /**< color of favorite button 1*/ 
    public Color favorite2Color; /**< color of favorite button 2*/
    public Color favorite3Color; /**< color of favorite button 3*/
    public Color favorite4Color; /**< color of favorite button 4*/

    public Vector3 favorite1Pos; /**< position of favorite 1 in app space*/
    public Vector3 favorite2Pos; /**< position of favorite 2 in app space*/
    public Vector3 favorite3Pos; /**< position of favorite 3 in app space*/
    public Vector3 favorite4Pos; /**< position of favorite 4 in app space*/

    public Vector2 favorite1Sound; /**< position of favorite 1 in board space*/
    public Vector2 favorite2Sound; /**< position of favorite 2 in board space*/
    public Vector2 favorite3Sound; /**< position of favorite 3 in board space*/
    public Vector2 favorite4Sound; /**< position of favorite 4 in board space*/

    public Vector3 crosshairPosition; /**< position of crosshair in app space */
    public Vector2 soundPosition; /**< position of crosshair in board space */

    public Vector3 lastCrosshairPos; /**< position of crosshair in app space from last played sound  */
    public Vector2 lastSoundPosition; /**< position of crosshair in board space from last played sound */

    public static GameControl control;

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
    public void restartTutorial()
    {
        this.onBoardingFinished = false;
    }

    /**
     * saves settings to binary file
     */
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

        settings.onBoardingFinished = onBoardingFinished;
        settings.visualization = visualization;
        settings.representation = representation;

        settings.soundSetting = soundSetting;

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

    /**
     * loads data from binary file
     */
    public void Load()
    {
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
            representation = settings.representation;
            onBoardingFinished = settings.onBoardingFinished;
            soundSetting = settings.soundSetting;

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
            visualization = 0;
            soundSetting = 0;
            representation = 0;

            favorite1Color = new Color(1.0F,1.0F,1.0F,1);
            favorite2Color = new Color(1.0F, 1.0F, 1.0F,1);
            favorite3Color = new Color(1.0F, 1.0F, 1.0F,1);
            favorite4Color = new Color(1.0F, 1.0F, 1.0F,1);
        }
    }

    /**
     * settings saved for a player
     */
    [Serializable]
    public class PlayerSettings
    {
        public int soundSetting; /**< toggle variable for switching between different sound modes */
        public bool onBoardingFinished;
        public int representation; /**< toggle variable for russel or uniform representation */
        public int visualization; /**< toggle variable for point label visualization*/
        private Color favorite1Color;
        /**
         * gets and sets favorite 1 color as color is not serializable
         */
        public Color Favorite1Color
        {
            get { return favorite1Color; }
            set { favorite1Color = value; }
        }
        private Color favorite2Color;
        /**
         * gets and sets favorite 2 color as color is not serializable
         */
        public Color Favorite2Color
        {
            get { return favorite2Color; }
            set { favorite2Color = value; }
        }
        private Color favorite3Color;
        /**
         * gets and sets favorite 3 color as color is not serializable
         */
        public Color Favorite3Color
        {
            get { return favorite3Color; }
            set { favorite3Color = value; }
        }
        private Color favorite4Color;
        /**
         * gets and sets favorite 4 color as Color is not serializable
         */
        public Color Favorite4Color
        {
            get { return favorite4Color; }
            set { favorite4Color = value; }
        }
        private Vector3 favorite1Pos;
        /** 
         * gets and sets favorite 1 position as Vector is not serializable
         */
        public Vector3 Favorite1Pos
        {
            get { return favorite1Pos; }
            set { favorite1Pos = value; }
        }
        private Vector3 favorite2Pos;
        /** 
         * gets and sets favorite 2 position as Vector is not serializable
         */
        public Vector3 Favorite2Pos
        {
            get { return favorite2Pos; }
            set { favorite2Pos = value; }
        }
        private Vector3 favorite3Pos;
        /** 
         * gets and sets favorite 3 position as Vector is not serializable
         */
        public Vector3 Favorite3Pos
        {
            get { return favorite3Pos; }
            set { favorite3Pos = value; }
        }
        private Vector3 favorite4Pos;
        /** 
         * gets and sets favorite 4 position as Vector is not serializable
         */
        public Vector3 Favorite4Pos
        {
            get { return favorite4Pos; }
            set { favorite4Pos = value; }
        }
        private Vector2 favorite1Sound;
        /**
         * gets and sets favorite 1 sound position as Vector is not serializable
         */
        public Vector2 Favorite1Sound
        {
            get { return favorite1Sound; }
            set { favorite1Sound = value; }
        }
        private Vector2 favorite2Sound;
        /**
         * gets and sets favorite 2 sound position as Vector is not serializable
         */
        public Vector2 Favorite2Sound
        {
            get { return favorite2Sound; }
            set { favorite2Sound = value; }
        }
        private Vector2 favorite3Sound;
        /**
         * gets and sets favorite 3 sound position as Vector is not serializable
         */
        public Vector2 Favorite3Sound
        {
            get { return favorite3Sound; }
            set { favorite3Sound = value; }
        }
        private Vector2 favorite4Sound;
        /**
         * gets and sets favorite 4 sound position as Vector is not serializable
         */
        public Vector2 Favorite4Sound
        {
            get { return favorite4Sound; }
            set { favorite4Sound = value; }
        }
    }
}
