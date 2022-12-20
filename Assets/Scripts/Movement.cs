using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000;
    [SerializeField] float rotationThrust = 1000;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

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

            if (!mainEngineParticles.isPlaying)
            {
                mainEngineParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    void ProcessRotation()
    {

        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            
            if (!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);

            if (!rightThrusterParticles.isPlaying)
            {
                rightThrusterParticles.Play();
            }
        }
        else 
        {
            leftThrusterParticles.Stop();
            rightThrusterParticles.Stop();
        }
    }

    void ApplyRotation(float rotationDirection)
    {
        playerRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationDirection * Time.deltaTime);
        playerRigidbody.freezeRotation = false;
    }
}
