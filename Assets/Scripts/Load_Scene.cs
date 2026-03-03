using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Load_Scene : MonoBehaviour
{
    float timer = 0f; // A timer that will go up and will be used for a condition
    
    void Update()
    {
        timer += Time.deltaTime; // Increasing time
        
        bool left = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame; // If mouse click is not null and is left
        bool right = Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame; // If mouse click is not null and is right

        if(timer >= 3f || left || right) // Timer reaches/goes over 3 or if left/right mouse was clicked
        {
            SceneManager.LoadScene("Invaders"); // Load into the 'Invaders' scene
        }
    }
}