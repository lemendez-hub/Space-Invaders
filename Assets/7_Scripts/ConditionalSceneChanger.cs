// Done for now
using UnityEngine;
using UnityEngine.SceneManagement;
public class ConditionalSceneChanger : MonoBehaviour
{
    float timer = 5f;
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log($"To Main Menu in: {timer}");
        if(timer <= 0f)
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }
}