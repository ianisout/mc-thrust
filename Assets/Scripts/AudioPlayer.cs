using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    static AudioPlayer instance;
    AudioSource audioSource;
    string scene;

    public AudioPlayer GetInstance()
    {
        return instance;
    }

    void Awake() {
        scene = SceneManager.GetActiveScene().name;
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (scene == "Space1" || scene == "Office" || scene == "Jungle")
        {
            instance.GetComponentInChildren<AudioSource>().enabled = false;
        }
        else if (instance != null && SceneManager.GetActiveScene().name == "MainMenu")
        {
            instance.GetComponentInChildren<AudioSource>().enabled = true;
        }
        else if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
