// Done for now
using UnityEngine;
using UnityEngine.SceneManagement;
public class L_SceneChanger : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}