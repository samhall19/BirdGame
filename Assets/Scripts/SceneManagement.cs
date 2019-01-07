using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour 
{
	public void Exit () 
	{
        //Quit application
        Application.Quit();
	}
	
	public void LoadScene (int sceneNumber) 
	{
        //Load scene
        SceneManager.LoadScene(sceneNumber);
    }
	
}
