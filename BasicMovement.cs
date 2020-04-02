using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the script being used for movement controls

public class BasicMovement : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;
    private Rigidbody self;
    private bool canMove;

    //Define "self":
    void Start()
    {
        self = GetComponent<Rigidbody>();
        canMove = true;
        self.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    //Basic Movement:
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        }
        else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("s"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("a") && !Input.GetKey("d") && canMove)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
            //transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a") && canMove)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
            //transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("e") && !Input.GetKey("q") && transform.position.y <= 33)
        {
            transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * movementSpeed * 2.5f;
        }
        else if (Input.GetKey("q") && !Input.GetKey("e") && transform.position.y >= 1)
        {
            transform.position += transform.TransformDirection(Vector3.down) * Time.deltaTime * movementSpeed;
        }

        // Stop player from moving in case they hit another object which causes velocity:
        if (Input.GetKey("r"))
        {
            self.velocity = Vector3.zero;
            self.angularVelocity = Vector3.zero;
        }
    }

    //Account for "Slime" objects:
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slow"))
        {
            movementSpeed = 5;
        }

        if (other.gameObject.CompareTag("Shark"))
        {
            movementSpeed = 0;
            canMove = false;
            self.constraints = RigidbodyConstraints.None;
        }
    }

    //Return to normal speed:
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Slow"))
        {
            movementSpeed = 10;
        }
    }
}
