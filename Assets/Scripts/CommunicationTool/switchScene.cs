using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * handles switching between scenes
 */
public class switchScene : MonoBehaviour {

	/**
	 * loads a scene based on the index in the build settings
	 * @param sceneIndex index of the scene which should be loaded
	 */
	public void loadByIndex(int sceneIndex) 
	{
		SceneManager.LoadScene(sceneIndex);
	}

}
