using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public Transform target;
    Rigidbody rb;
    public float moveSpeed = 100;
    public float rotateSpeed;

    void Start()
    {
        //Get rigid body component
        rb = GetComponent<Rigidbody>();

        //Get player's transform if it wasn't set in editor
        if (target == null)
        {
            target = GameObject.Find("Player").transform;
        }
    }

    void Update()
    {
        ObstaclesAvoidance();
    }


    void ObstaclesAvoidance()
    {
        LookAtPlayer();
        RaycastHit hit;
        float rayLength = 0.3f;

        Vector3 position = transform.position;


        Debug.DrawRay(position, transform.forward * rayLength, Color.cyan);
        Debug.DrawRay(position, transform.right * rayLength, Color.cyan);
        Debug.DrawRay(position,  transform.right * -rayLength, Color.cyan);
        Debug.DrawRay(position, transform.up * -rayLength, Color.cyan);

        //If there is an obstacle forward, left and right, go up
        if (Physics.Raycast(position, transform.forward, out hit, rayLength) && Physics.Raycast(position, -transform.right, out hit, rayLength) && Physics.Raycast(position, transform.right, out hit, rayLength))
        {
            Motor(transform.up, moveSpeed / 2);
        }

        //If an obstacle is in front and left, go up
        else if (Physics.Raycast(position, transform.forward, out hit, rayLength) && Physics.Raycast(position, -transform.right, out hit, rayLength))
        {
            Motor(transform.up, moveSpeed / 2);
        }

        //If an obstacle is in front and right, go left
        else if (Physics.Raycast(position, transform.forward, out hit, rayLength) && Physics.Raycast(position, transform.right, out hit, rayLength))
        {
            Motor(transform.up, moveSpeed / 2);
        }

        // If an obstacle is in front, go left
        else if (Physics.Raycast(position, transform.forward, out hit, rayLength))
        {
            Motor(-transform.right, moveSpeed / 2);
        }

        // If an obstacle is in left, go right
        else if (Physics.Raycast(position, -transform.right, out hit, rayLength))
        {
            Motor(transform.right, moveSpeed / 2);
        }

        // If an obstacle is in right, go left
        else if (Physics.Raycast(position, transform.right, out hit, rayLength))
        {
            Motor(-transform.right, moveSpeed /2 );
        }

        // If an obstacle is in front, go left
        else if (Physics.Raycast(position, transform.forward, out hit, rayLength))
        {
            Motor(-transform.right, moveSpeed / 2);
        }

        // If an obstacle is in down, go up
        else if (Physics.Raycast(position, -transform.up, out hit, rayLength))
        {
            Motor(transform.up, moveSpeed / 2);
        }

        else
        {
            LookAtPlayer();
            Motor(transform.forward, moveSpeed);
        }
    }

    void LookAtPlayer()
    {
        if (target != null)
        {
            var rotation = Quaternion.LookRotation(target.position - transform.position);

            //Rotate towards player
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
        }
    }

    void Motor(Vector3 dir, float speed)
    {
        //Move forward
        rb.velocity = dir * speed;
    }

}
