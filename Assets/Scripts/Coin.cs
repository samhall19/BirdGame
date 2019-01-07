using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public GameObject particles;
    public AudioClip coinSound;

    private void Update()
    {
        //Constant Rotation
        transform.Rotate(50 * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter (Collider col)
    {
        //Checks if collided with player
        if (col.name == "Player")
        {
            //Play coin sound through player's audio source
            col.GetComponent<AudioSource>().PlayOneShot(coinSound);

            //Runs the Add coin function on the coin UI
            GameObject.Find("Canvas").GetComponent<CoinUI>().AddCoin();

            //Destroy this coin
            Destroy(gameObject);
        }
	}
}
