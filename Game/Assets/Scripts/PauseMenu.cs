using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input to pause the game
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }

        // Check for input to go back when the pause menu is active
        if (Paused && Input.GetKeyUp(KeyCode.B))
        {
            MainMenuButton(); // Sử dụng lại hàm MainMenuButton
        }
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        AudioListener.pause = true; // Tắt âm thanh
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        AudioListener.pause = false; // Bật âm thanh
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        AudioListener.pause = false; // Bật âm thanh khi quay lại main menu
    }
}
