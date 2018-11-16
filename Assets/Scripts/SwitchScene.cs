using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {
    /**
	 * This manages to load scene
	 */
    public void loadByIndex(int sceneIndex) 
	{
		SceneManager.LoadScene(sceneIndex);
	}

}
