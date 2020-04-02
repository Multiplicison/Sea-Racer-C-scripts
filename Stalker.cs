using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shark behavior script

public class Stalker : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    private Rigidbody self;
    private Vector3 randDirection;
    public float turnTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Rigidbody>();
        //randDirection = (new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f))).normalized;
    }

    // Calculate distance to player and follow if close:
    void Update()
    {
        float tick = speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= 20f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, tick);
            transform.LookAt(target);
        }
        else if(distance > 20f)
        {
            self.velocity = Vector3.zero;
            self.angularVelocity = Vector3.zero;
            //Set random point as new target to give natural movement.
            //transform.LookAt(-randDirection);
            transform.position += randDirection * speed * Time.deltaTime;
            turnTime -= Time.deltaTime;

            //Change direction every 5 seconds
            if(turnTime <= 0)
            {
                randDirection = (new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f))).normalized;
                transform.LookAt(randDirection);
                //transform.position += randDirection * speed * Time.deltaTime;
                turnTime = 5.0f;
            }
        }
    }
}
