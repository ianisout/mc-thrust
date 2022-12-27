using UnityEngine;

public class AudioLanding : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) {
        audioSource.PlayOneShot(audioClip);
    }
}
