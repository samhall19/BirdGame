using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceFromDragon : MonoBehaviour 
{
    public Transform dragon;
    public Transform player;
    public Text distanceText;
    public Slider slider;
    float distance;

    void Start () 
	{
        //Finds dragon if null
        if (dragon == null)
        {
            dragon = GameObject.Find("Dragon").transform;
        }

        //Finds player if null
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }
    }

    void Update()
    {
        //Get the distance from dragon to player
        distance = Vector3.Distance(dragon.position, player.position);

        //Set text to display distance between dragon and player
        distanceText.text = "Distance from dragon: " + distance.ToString("F1") + "m";

        slider.value = distance / 10;
    }

}
