using UnityEngine;
using UnityEngine.SceneManagement;

public class ConditionalSceneChanger : MonoBehaviour
{
    float timer = 5f; // Total countdown time

    void Update()
    {
        timer -= Time.deltaTime; // Counting down

        if(timer <= 0f) // If timer is finished
        {
            SceneManager.LoadScene("Main_Menu"); // Change to Main Menu
        }
    }
}