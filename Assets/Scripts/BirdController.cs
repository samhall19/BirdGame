using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float currentMoveSpeed = 1;
    public float rotateSpeed = 1;
    public float dropOffSpeed;
    float baseMoveSpeed;
    public float pitchRotateSpeed;
    public float rollRotateSpeed;
    public float yawRotateSpeed;
    public float elevationSpeed;
    Rigidbody rb;
    public GameObject featherParticles;

    AudioSource audioSource;
    public AudioClip crashSound;
    public AudioClip speedUpSound;

    void Start ()
    {
        //Set base speed
        baseMoveSpeed = currentMoveSpeed;

        //Get rigidbody component
        rb = GetComponent<Rigidbody>();

        //Get audiosource component
        audioSource = GetComponent<AudioSource>();
	}

    void Update ()
    {
        NewRotation();
        Motor();
        Elevation();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Play crash Sound
       audioSource.PlayOneShot(crashSound);

        //spawn feather particles
        Instantiate(featherParticles, transform.position, Quaternion.identity);

        //Destory visuals
        Destroy(transform.GetChild(0).gameObject);

        //Destroy player's rigidbody
        Destroy(GetComponent<Rigidbody>());

        //Set dragon's target to null
        GameObject.Find("Dragon").GetComponent<AIController>().target = null;

        //Checks if collided with goal
        if (collision.gameObject.tag == "Goal")
        {
            //Enable the win panel in the canvas
            GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            //Enable the game over panel in the canvas
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
        }

        //Destroy this script
        Destroy(this);
    }

    void Elevation()
    {
        //Get elevation Inputs
        bool elevationUp = Input.GetButton("ElevationUp");
        bool elevationDown = Input.GetButton("ElevationDown");

        if (elevationUp)
        {
            //Move up
            transform.localPosition += new Vector3(0, elevationSpeed * Time.deltaTime ,0);
        }
        if (elevationDown)
        {
            //Move down
            transform.localPosition += new Vector3(0, -elevationSpeed * Time.deltaTime , 0);
        }
    }

    void Motor()
    {
        //Get speed Inputs
        float brakeAmount = Input.GetAxis("Brake");
        float sprintAmount = Input.GetAxis("Sprint");

        //Calculates new current move speed
        currentMoveSpeed = baseMoveSpeed + (sprintAmount * baseMoveSpeed) - (brakeAmount * (baseMoveSpeed / 2));

        //Add forwards velocity based on current move speed
        rb.velocity = transform.forward * currentMoveSpeed;
    }

    void NewRotation()
    {
        //Get values for new rotation from inputs
        float yaw = Input.GetAxis("Yaw");
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        //Rotate to new position
        transform.Rotate(vertical * pitchRotateSpeed * Time.deltaTime, yaw * yawRotateSpeed * Time.deltaTime, -horizontal * rollRotateSpeed * Time.deltaTime);
    }
}
