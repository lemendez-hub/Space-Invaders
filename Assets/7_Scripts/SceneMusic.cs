using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusic : MonoBehaviour
{
    // Will be for different audios
    public AudioClip menu;
    public AudioClip game;
    public AudioClip win;
    public AudioClip lose;

    // Play Music in the Scenes
    void Awake()
    {
        PlayMusic();
    }

    void PlayMusic()
    {
        // Music will depend on Scene Name
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Main_Menu")
        {
            GetComponent<AudioSource>().PlayOneShot(menu);
        }

        if (currentScene == "Main_Game")
        {
            GetComponent<AudioSource>().PlayOneShot(game);
        }

        if (currentScene == "Credits_Win")
        {
            GetComponent<AudioSource>().PlayOneShot(win);
        }

        if (currentScene == "Credits_Lose")
        {
            GetComponent<AudioSource>().PlayOneShot(lose);
        }
    }
}