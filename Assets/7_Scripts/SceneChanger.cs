using UnityEngine;
using UnityEngine.SceneManagement;

// Changing Scenes, used for Menu
public class SceneChanger : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}