// Done for now
using UnityEngine;
using UnityEngine.SceneManagement;
public class M_SceneChanger2 : MonoBehaviour
{
    float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer >= 5)
        {
            Debug.Log("Alright, back to Main_Menu.");
            SceneManager.LoadScene("Main_Menu");
        }
    }
}