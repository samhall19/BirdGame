using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour 
{
    public Text timeText;

	void Update () 
	{
        //Sets time text to time since level was loaded
        timeText.text = "Time Elapsed: " + Time.timeSinceLevelLoad.ToString("F1") + "s";
	}
}
