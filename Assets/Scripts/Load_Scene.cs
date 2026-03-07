using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Load_Scene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //float timer = 0f; // A timer that will increase and be used for a condition
    
    //void Update()
    //{
    //    timer += Time.deltaTime; // Increasing time
        
    //    bool left = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame; // If mouse click is not null and is left
    //    bool right = Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame; // If mouse click is not null and is right
    //    if(timer >= 3f || left || right) // Timer reaches/goes over 3 or if left/right mouse was clicked
    //    {
    //        ScoreManager.instance.ResetScore();
    //        SceneManager.LoadScene("Invaders"); // Load into the 'Invaders' scene
    //    }
    //}
}