using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PausePlay : MonoBehaviour
{
    bool ispaused = false;
    public GameObject pausemenu;

    public void PauseGame() {
            Time.timeScale = 0;
            ispaused = true;
            pausemenu.SetActive(true);
        
        
    }
    public void Resumegame() {
        Time.timeScale = 1;
        ispaused = false;
        pausemenu.SetActive(false);
    }

    public void Restart() {
        ispaused = false;
        pausemenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMainMenu()
    {
        ispaused = false;
        pausemenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("CarsMenu");
    }

}
