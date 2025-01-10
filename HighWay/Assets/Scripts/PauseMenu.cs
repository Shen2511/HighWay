using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; 

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           Resume();
        }
    }
    public void Resume()
    {
        isPaused = !isPaused; pausePanel.SetActive(isPaused); if (isPaused)
        {
            Time.timeScale = 0f;  
        } 
        else 
        { 
            Time.timeScale = 1f; 
        }


        }
    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
