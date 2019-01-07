using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform player;

	void Start ()
    {
        //Check for player transform 
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
            if (player == null)
            {
                Debug.Log("No player was found");
            }
        }
	}
	
	void LateUpdate ()
    {
        //Update minimap camera position minus the y.
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //Update minimap camera position to player's y rotation.
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
