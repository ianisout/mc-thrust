using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000;
    [SerializeField] float rotationThrust = 50;
    [SerializeField] List<AudioClip> mainEngineSFX;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    bool rotationStatus = false;

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

        if(rotationStatus)
        {
            RotateForLanding();
        }
    }

    int GetRandomThrustSFX()
    {
        int limitNumber = mainEngineSFX.Count;
        int randomSFXIndex = Random.Range(0, limitNumber);

        return randomSFXIndex;
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        playerRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSFX[GetRandomThrustSFX()]);
        }

        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(rotationThrust);

        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(-rotationThrust);

        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

    void StopRotating()
    {
        leftThrusterParticles.Stop();
        rightThrusterParticles.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (!rotationStatus)
            {
                RotateLeft();
            }
            else
            {
                transform.Rotate(-1, 0, 0.1f * 1 * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!rotationStatus)
            {
                RotateRight();
            }
            else
            {
                transform.Rotate(1, 0, 0.1f * 1 * Time.deltaTime);
            }
        }
        else
        {
            StopRotating();
        }
    }

    void ApplyRotation(float rotationDirection)
    {
        playerRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationDirection * Time.deltaTime);
        playerRigidbody.freezeRotation = false;
    }

    void OnTriggerEnter(Collider other) 
    {        
        playerRigidbody.drag = 3;

        if (!rotationStatus)
        {
            rotationStatus = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        // playerRigidbody.drag = 10;

        // CREATE YOU'RE LOSING THE BATTLE MESSAGE
    }

    void RotateForLanding()
    {
        if (transform.rotation.y < 0.7)
        {
            transform.Rotate(0, 1, 0 * 100 * Time.deltaTime);
        }
    }
}

// for further reference (maybe?)
// transform.Rotate(0, 90, 0 * 100 * Time.deltaTime);