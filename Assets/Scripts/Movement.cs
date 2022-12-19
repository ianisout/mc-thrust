using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000;
    [SerializeField] float rotationThrust = 1000;
    [SerializeField] AudioClip mainEngine;

    Rigidbody playerRigidbody;
    AudioSource audioSource;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.A))
            {
                ApplyRotation(rotationThrust);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                ApplyRotation(-rotationThrust);
            }
            // if (Input.GetAxis("Mouse Z") < 0){
            //     transform.Rotate(Vector3.left * rotationThrust * Time.deltaTime);
            // }
            // else if (Input.GetAxis("Mouse Z") > 0){
            //     transform.Rotate(Vector3.right * rotationThrust * Time.deltaTime);
            // }
        }
    }

    void ApplyRotation(float rotationDirection)
    {
        playerRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationDirection * Time.deltaTime);
        playerRigidbody.freezeRotation = false;
    }
}
