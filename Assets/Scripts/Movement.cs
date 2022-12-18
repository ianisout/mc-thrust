using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000;
    [SerializeField] float rotationThrust = 1000;

    Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
        /* else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left * rotationThrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * rotationThrust * Time.deltaTime);
        } */
    }

    void ApplyRotation(float rotationDirection)
    {
        playerRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationDirection * Time.deltaTime);
        playerRigidbody.freezeRotation = false;
    }
}
