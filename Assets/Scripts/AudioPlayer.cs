using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    // [SerializeField] AudioClip audioClip;
    static AudioPlayer instance;
    AudioSource audioSource;
    string scene;

    public AudioPlayer GetInstance()
    {
        return instance;
    }

    void Awake() {
        // ManageSingleton();
    }

    void Start()
    {
        // Debug.Log("Start: " + SceneManager.GetActiveScene().name);
        // audioSource = instance.GetComponentInChildren<AudioSource>();
        // audioClip = GetComponent<AudioClip>();
        // Debug.Log("audioSource: " + audioSource);
        // Debug.Log(audioClip.name);
    }

    void ManageSingleton()
    {
        // Debug.Log("Start: " + SceneManager.GetActiveScene().name);

        // Debug.Log(instance);
        // if (SceneManager.GetActiveScene().name == "Over")
        // {
        //     Debug.Log(instance);
        // }
        // {
            // instance.GetComponentInChildren<AudioSource>().enabled = false;
        // }
        // else if (SceneManager.GetActiveScene().name == "GameOver")
        /* {
            instance.GetComponentInChildren<AudioSource>().enabled = true;
        }
        else */
        
        if (instance != null && SceneManager.GetActiveScene().name == instance.GetComponentInChildren<AudioSource>().clip.name)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            // if (instance != null && SceneManager.GetActiveScene().name != instance.GetComponentInChildren<AudioSource>().clip.name)
            // {
            //     Destroy(gameObject);
            // }

            instance = this;
            DontDestroyOnLoad(gameObject);

            if (SceneManager.GetActiveScene().name != null && 
                instance.GetComponentInChildren<AudioSource>().clip.name != null &&
                SceneManager.GetActiveScene().name != instance.GetComponentInChildren<AudioSource>().clip.name)
            {
                Destroy(gameObject);
            }
        }
    }
}
