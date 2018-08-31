using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LockController : MonoBehaviour {
    public Button[] mybuttons;
    public Sprite lock_image;
   
    // Use this for initialization
    void Start () {

        int level = PlayerPrefs.GetInt("level", 1);
        for (int i = level; i < mybuttons.Length; i++)
        {
            mybuttons[i].GetComponent<Image>().sprite = lock_image;
            mybuttons[i].GetComponent<Button>().interactable = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //level = Duplicator.a+1;
        

    }
    public void loadByIndex(int sceneIndex)
    {
        StaticClass.CrossSceneInformation = sceneIndex.ToString();
        SceneManager.LoadScene(sceneIndex);
    }
    public static class StaticClass
    {
        public static string CrossSceneInformation { get; set; }
    }
}
